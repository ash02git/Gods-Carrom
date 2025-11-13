 namespace GodsCarrom.Gameplay
{
    public enum GameplayPhase
    {
        None,
        AbilitySelectionPhase,
        PreMovePhase,
        PlayerPhase,//the phase where the player decides which piece to shoot and the angle and power.
        InMovePhase,
        PhysicsPhase,//the phase where the Physics happens after the player has completed his input, this phase is over
        //when all the pieces on the board stop moving
        PostMovePhase,
        TurnCompletedPhase
    }
}