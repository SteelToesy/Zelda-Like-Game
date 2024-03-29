﻿using Assignments.Assignment1;
using Assignments.Assignment3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignments.Assignment2
{
    enum EnemyState
    {
        Idle,
        Patrolling,
        Chasing,
        Evading
    }

    internal class Enemy : GameObject
    {
        float time = 0;
        float idleDelay = 5;
        float idleStopTime = 1.5f;

        private GameObject _player;
        private EnemyState _state;
        private Flag[] _flags;
        int targetFlag = 0;
        private int _speed;
        Vector2 directionPlayer;

        public Enemy(Texture2D pTexture, GameObject pPlayer, params Flag[] pFlags) : base("Enemy")
        {
            _state = EnemyState.Patrolling;
            _texture = pTexture;
            _flags = pFlags;
            _player = pPlayer;
            _speed = 100;
        }
        public override void Update(GameTime pGameTime)
        {
            
            directionPlayer = _player.position - position;

            switch (_state)
            {
                case EnemyState.Idle:
                    Idle();
                    _speed = 0;
                    break;
                case EnemyState.Patrolling:
                    _speed = 75;
                    Patrol(pGameTime);
                    if (directionPlayer.Length() < 175 && _player.textureIndexer == 3) 
                        _state = EnemyState.Evading;
                    else if (directionPlayer.Length() < 175)
                        _state = EnemyState.Chasing;
                    if (time >= idleDelay)
                    {
                        _state = EnemyState.Idle;
                        time = 0;
                    }
                    break;
                case EnemyState.Chasing:
                    _speed = 100;
                    MoveTowards(pGameTime, directionPlayer, false);
                    if (directionPlayer.Length() > 175)
                        _state = EnemyState.Patrolling;
                    if (time >= idleDelay)
                    {
                        _state = EnemyState.Idle;
                        time = 0;
                    }
                    break;
                case EnemyState.Evading:
                    _speed = 150;
                    MoveTowards(pGameTime, directionPlayer, true);
                    if (directionPlayer.Length() > 200)
                        _state = EnemyState.Patrolling;
                    break;
            }

            time += (float)pGameTime.ElapsedGameTime.TotalSeconds;
            idleDelay = (time < idleDelay + 0.1f ? idleDelay : time + 4);

            base.Update(pGameTime);
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }

        public void MoveTowards(GameTime pGameTime, Vector2 pDirection, bool pEvading)
        {
            float dt = (float)pGameTime.ElapsedGameTime.TotalSeconds;
            if (pDirection != Vector2.Zero)
                pDirection.Normalize();

            if (pEvading)
                position -= pDirection * _speed * dt;
            else
                position += pDirection * _speed * dt;
        }

        public void Patrol(GameTime pGameTime)
        {
            Vector2 dir = _flags[targetFlag].position - position;
            MoveTowards(pGameTime, dir, false);
            if (dir.Length() < 2)
            {
                if (targetFlag == _flags.Length - 1)
                    targetFlag = 0;
                else
                    targetFlag++;
            }
        }

        public void Idle()
        {
            if (time >= idleStopTime)
            {
                time = 0;
                idleStopTime = (time < idleStopTime + 0.1f ? idleStopTime : time + 4);
                    _state = EnemyState.Patrolling;
            }
        }
    }
}
