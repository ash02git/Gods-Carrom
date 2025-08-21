namespace GodsCarrom.Abilites
{
    public enum AbilitiesEnum
    {
        Resurrect,//Jesus - Resurrects n number of pieces ( Pre move)
        LoveAll,//Jesus - Opponents pieces will not collide with you pieces( Post move)
        WaterToWine,//Jesus - Convert one random opponents piece to your piece( Pre move)
        ThunderSmash,//Thor and Zeus - First piece that is struck is instantly destroyed( In move)
        PowerShot,//Thor - 2x speed for striking piece( In move)
        SuperStrength,//Thor - 2x weight for striking piece( In move)
        Disguise,//Loki - All pieces temporarily change appearance to look the same( Post move)
        Trickster,//Loki - Loki uses a random ability of the opponent ( Pre move)
        ShapeShift,//Loki - 
        ChakraSlice,//Vishnu - Striking piece slices all pieces that it connects with ( In move)
        Dashavatar,//Vishnu - 
        CreateAndDestory,//Vishnu - Spawns new piece, deletes one enemy piece ( Post move)
        ThirdEye,//Shiva - n number of random opponent piece(s) is disintegrated ( Post move)
        ThrisulAttack,//Shiva - 
        Distort,//Shiva - Distorts the view to make it harder for opponent to move( Post move)
        CloudVision,//Zeus - Clouds cover the board, opponent has to guess his shot ( Post move)
        SireDemigods,//Zeus - spawns 2 half sized carrom men
        Darkness,//Hades - Darkness covers the board, opponent has to guess his shot( Post move)
        TradeDeath,//Hades - If you pot a piece, you gain a piece( In move)
        Invisibility//Hades - Your pieces become invisible, opponent has to guess his shot ( Post Move)
    }
}

/*
 * Note for Mentor:- 
 * Basically there are three types of abilities:- 
 * 1. That affects the striking piece - Typically done InMove
 * 2. Creating or destroying new pieces - Typically done PreMove
 * 3. Denying vision of the board or distorting the board - Typically done PostMove (makes it harder for opponents)
 * 
 * I must find the flow of checks regarding turns, ability selected and ability cast.
*/