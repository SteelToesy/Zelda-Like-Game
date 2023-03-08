using Assignments.Assignment1;
using Assignments.Assignment2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Assignments.Assignment3
{
    class Enemy : GameObject
    {
        public EnemyStateBase enemyIdle;
        public EnemyStateBase enemyPatrolling;
        public EnemyStateBase enemyChasing;
        public EnemyStateBase enemyEvading;

        public EnemyStateBase currentState;

        public Player player;
        public SceneManager sceneManager;
        public Enemy(Vector2 pPosition, Texture2D pTexture, float pSpeed, SceneManager pSceneManager, Player pPlayer, params Flag[] pFlags) : base(pPosition)
        {
            _texture = pTexture;
            position = pPosition;
            player = pPlayer;
            sceneManager = pSceneManager;

            enemyIdle = new EnemyStateIdle(this);
            enemyPatrolling = new EnemyStatePatrolling(this, pPlayer, pSpeed, pFlags);
            enemyChasing = new EnemyStateChasing(this, pPlayer, pSpeed);
            enemyEvading = new EnemyStateEvading(this, pPlayer, pSpeed);

            currentState = enemyPatrolling;
        }
        public override void Update(GameTime pGameTime)
        {
            OnCollision();
            currentState.Update(pGameTime);
        }
        public override void Draw(SpriteBatch pSpritebatch)
        {
            pSpritebatch.Draw(_texture, position, Color.White);
        }

        public override void OnCollision()
        {
            if (this.collisionBox.Intersects(player.collisionBox))
            {
                if (player.textureIndexer == (int)PlayerTexture.PlayerWithWeaponAndShield)
                {
                    active = false;
                    sceneManager.enemiesKilled++;
                }
                else
                    player.TakeDamage();
            }
        }

        public class EnemyStateBase
        {
            protected Enemy _enemy;
            public EnemyStateBase(Enemy pEnemy)
            {
                _enemy = pEnemy;
            }

            public virtual void Update(GameTime pGameTime) { }
        }

        class EnemyStateIdle : EnemyStateBase
        {
            private float time = 0;
            private float idleStopTime = 1.5f;
            public EnemyStateIdle(Enemy pEnemy) : base(pEnemy)
            {

            }

            public override void Update(GameTime pGameTime)
            {
                if (time >= idleStopTime)
                {
                    time = 0;
                    idleStopTime = (time < idleStopTime + 0.1f ? idleStopTime : time + 4);
                    _enemy.currentState = _enemy.enemyPatrolling;
                }

                time += (float)pGameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        class EnemyStatePatrolling : EnemyStateBase
        {
            private float deltaTime;
            private float time = 0;
            private float idleDelay = 5;

            private float _speed;

            private int _targetFlag;
            private Flag[] _flags;

            private Player _player;
            private Vector2 directionPlayer;

            public EnemyStatePatrolling(Enemy pEnemy, Player pPlayer, float pSpeed, params Flag[] pFlags) : base(pEnemy)
            {
                _player = pPlayer;
                _flags = pFlags;
                _speed = pSpeed * 0.75f;
            }

            public override void Update(GameTime pGameTime)
            {
                time += (float)pGameTime.ElapsedGameTime.TotalSeconds;
                deltaTime = (float)pGameTime.ElapsedGameTime.TotalSeconds;

                PatrolRoute();
                CheckForPlayer();
                IdleCounter();
            }

            public void PatrolRoute()
            {
                Vector2 dir = _flags[_targetFlag].position - _enemy.position;

                if (dir != Vector2.Zero)
                    dir.Normalize();
                _enemy.position += dir * _speed * deltaTime;

                if (_enemy.collisionBox.Intersects(_flags[_targetFlag].collisionBox))
                {
                    if (_targetFlag == _flags.Length - 1)
                        _targetFlag = 0;
                    else
                        _targetFlag++;
                }
            }

            public void CheckForPlayer()
            {
                directionPlayer = _player.position - _enemy.position;

                if (directionPlayer.Length() < 150 && _player.textureIndexer == 3)
                    _enemy.currentState = _enemy.enemyEvading;
                else if (directionPlayer.Length() < 150)
                    _enemy.currentState = _enemy.enemyChasing;
            }

            public void IdleCounter()
            {
                idleDelay = (time < idleDelay + 0.1f ? idleDelay : time + 4);

                if (time >= idleDelay)
                {
                    _enemy.currentState = _enemy.enemyIdle;
                    time = 0;
                }
            }
        }

        class EnemyStateChasing : EnemyStateBase
        {
            private float _speed;

            private float deltaTime;
            private float time = 0;
            private float idleDelay = 5;

            private Player _player;
            private Vector2 _directionPlayer;
            public EnemyStateChasing(Enemy pEnemy, Player pPlayer, float pSpeed) : base(pEnemy)
            {
                _player = pPlayer;
                _speed = pSpeed * 1.5f;
            }

            public override void Update(GameTime pGameTime)
            {
                time += (float)pGameTime.ElapsedGameTime.TotalSeconds;
                deltaTime = (float)pGameTime.ElapsedGameTime.TotalSeconds;


                Chasing();
                IdleCounter();
                CheckForPlayer();
            }

            public void Chasing()
            {
                _directionPlayer = _player.position - _enemy.position;
                _directionPlayer.Normalize();
                _enemy.position += _directionPlayer * _speed * deltaTime;
            }

            public void IdleCounter()
            {
                idleDelay = (time < idleDelay + 0.1f ? idleDelay : time + 4);

                if (time >= idleDelay)
                {
                    _enemy.currentState = _enemy.enemyIdle;
                    time = 0;
                }
            }

            public void CheckForPlayer()
            {
                if (_directionPlayer.Length() > 1f)
                    _enemy.currentState = _enemy.enemyPatrolling;
            }
        }

        class EnemyStateEvading : EnemyStateBase
        {
            private float deltaTime;
            private float _speed;
            private Player _player;
            private Vector2 _directionPlayer;
            public EnemyStateEvading(Enemy pEnemy, Player pPlayer, float pSpeed) : base(pEnemy)
            {
                _player = pPlayer;
                _speed = pSpeed * 1.75f;
            }

            public override void Update(GameTime pGameTime)
            {
                deltaTime = (float)pGameTime.ElapsedGameTime.TotalSeconds;

                Evade();
                CheckForPlayer();
            }

            public void Evade()
            {
                _directionPlayer = _player.position - _enemy.position;

                _directionPlayer.Normalize();
                _enemy.position -= _directionPlayer * _speed * deltaTime;
            }

            public void CheckForPlayer()
            {
                if (_directionPlayer.Length() > 1)
                    _enemy.currentState = _enemy.enemyPatrolling;
            }
        }
    }
}
