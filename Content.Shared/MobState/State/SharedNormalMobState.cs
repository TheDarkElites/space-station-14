﻿using Content.Shared.Standing;
using Robust.Shared.GameObjects;


namespace Content.Shared.MobState.State
{
    /// <summary>
    ///     The standard state an entity is in; no negative effects.
    /// </summary>
    public abstract class SharedNormalMobState : BaseMobState
    {
        protected override DamageState DamageState => DamageState.Alive;

        public override void EnterState(IEntity entity)
        {
            base.EnterState(entity);
            EntitySystem.Get<StandingStateSystem>().Stand(entity.Uid);

            if (entity.TryGetComponent(out SharedAppearanceComponent? appearance))
            {
                appearance.SetData(DamageStateVisuals.State, DamageState.Alive);
            }
        }
    }
}
