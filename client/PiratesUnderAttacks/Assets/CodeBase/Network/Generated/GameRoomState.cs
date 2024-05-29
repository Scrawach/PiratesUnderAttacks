// 
// THIS FILE HAS BEEN GENERATED AUTOMATICALLY
// DO NOT CHANGE IT MANUALLY UNLESS YOU KNOW WHAT YOU'RE DOING
// 
// GENERATED USING @colyseus/schema 2.0.32
// 

using Colyseus.Schema;
using Action = System.Action;

namespace CodeBase.Generated {
	public partial class GameRoomState : Schema {
		[Type(0, "map", typeof(MapSchema<PlayerSchema>))]
		public MapSchema<PlayerSchema> players = new MapSchema<PlayerSchema>();

		/*
		 * Support for individual property change callbacks below...
		 */

		protected event PropertyChangeHandler<MapSchema<PlayerSchema>> __playersChange;
		public Action OnPlayersChange(PropertyChangeHandler<MapSchema<PlayerSchema>> __handler, bool __immediate = true) {
			if (__callbacks == null) { __callbacks = new SchemaCallbacks(); }
			__callbacks.AddPropertyCallback(nameof(this.players));
			__playersChange += __handler;
			if (__immediate && this.players != null) { __handler(this.players, null); }
			return () => {
				__callbacks.RemovePropertyCallback(nameof(players));
				__playersChange -= __handler;
			};
		}

		protected override void TriggerFieldChange(DataChange change) {
			switch (change.Field) {
				case nameof(players): __playersChange?.Invoke((MapSchema<PlayerSchema>) change.Value, (MapSchema<PlayerSchema>) change.PreviousValue); break;
				default: break;
			}
		}
	}
}
