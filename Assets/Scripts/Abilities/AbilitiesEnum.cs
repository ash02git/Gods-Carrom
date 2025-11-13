namespace GodsCarrom.Abilites
{
    public enum AbilitiesEnum
    {
        Resurrect,//Jesus - Resurrects n number of pieces ( Pre move) - DONE - done
        LoveAll,//Jesus - Opponents pieces will not collide with you pieces( Post move) - DONE - done
        WaterToWine,//Jesus - Convert one random opponents piece to your piece( Pre move) - DONE - done
        ThunderSmash,//Thor and Zeus - First piece that is struck is instantly destroyed( In move) - DONE - done
        PowerShot,//Thor - 2x speed for striking piece( In move) - to be determined - DONE - done
        SuperStrength,//Thor - 2x weight for striking piece( In move) -  determined - DONE - done

        Disguise,//Loki - All pieces temporarily change appearance to look the same( Post move) - to be rethought
        Trickster,//Loki - Loki uses a random ability of the opponent ( Pre move) - to be rethought
        ShapeShift,//Loki - to be rethought

        ChakraSlice,//Vishnu - Striking piece slices all pieces that it connects with ( In move)
        Dashavatar,//Vishnu - to be rethought
        CreateAndDestory,//Vishnu - Spawns new piece, deletes one enemy piece ( Post move)
        ThirdEye,//Shiva - n number of random opponent piece(s) is disintegrated ( Post move)
        ThrisulAttack,//Shiva - 

        Distort,//Shiva - Distorts the view to make it harder for opponent to move( Post move) - DONE - done
        CloudVision,//Zeus - Clouds cover the board, opponent has to guess his shot ( Post move) - DONE - need to get the asset for it
        SireDemigods,//Zeus - spawns 2 half sized carrom men - DONE
        Darkness,//Hades - Darkness covers the board, opponent has to guess his shot( Post move) - DONE - need to get the asset for it

        TradeDeath,//Hades - If you pot a piece, you gain a piece( In move)

        Invisibility//Hades - Your pieces become invisible, opponent has to guess his shot ( Post Move) - DONE - done
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
