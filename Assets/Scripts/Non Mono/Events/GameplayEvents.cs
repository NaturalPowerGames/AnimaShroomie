using System;
public static class GameplayEvents
{
	public static Action<int> OnCoinPickedUp;
	public static Action<int> OnCoinTotalChanged;
	public static Action<SFX> OnSFXRequested;
	public static Action<int> OnPlayerHealthChanged;	
	/* enemy damage
	 * player damage
		player heal 
	 player sword
	item picked up
	level complete
	level start
	level lost
	continue
	 */
}
