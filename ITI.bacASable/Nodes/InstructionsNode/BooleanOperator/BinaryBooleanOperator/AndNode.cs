﻿using System;

namespace ITI.bacASable
{
    /// <summary>
    /// Bitwise AND of two integral values, returns an integral value.
    /// </summary>
    public class AndNode : BinaryBooleanOperatorNode
    {
        public AndNode(int line)
            : base( line )
        {
        }
        protected override IValue Operator( IValue value1, IValue value2 )
        {
            IValue result;
            if ( Convert.ToBoolean( value1.Data ) && Convert.ToBoolean( value2.Data ) )
            {
                result = new Value( value1.Type, 1 );
            }
            else
            {
                result = new Value( value1.Type, 0 );
            }
            return result;
        }
    }
}




/*

                         ooMMMMMMMooo
                       oMMMMMMMMMMMMMMMoo
                      MMMMMMMMMMMMMMo"MMMo
                     "MMMMMMMMMMMMMMMMMMMMM
                     MMMMMMMMMMMMMMMMMMMMMMo
                     MMMM""MMMMMM"o" MMMMMMM
                     MMo o" MMM"  oo ""MMMMM
                     MM MMo MMM" MMoM "MMMMM
                     MMo"M"o" "" MMM" oMMMMM"
                     oMM M  o" " o "o MMMMMM"
                     oM"o " o "  o "o MMMMMMM
                     oMMoM o " M M "o MMMM"MMo
                      Mo " M "M "o" o  MMMoMMMo
                     MMo " "" M "       MMMMMMMo
                   oMM"   "o o "         MMMMMMMM
                  MMM"                    MMMMMMMMo
                oMMMo                     "MMMMMMMMo
               MMMMM o             "  " o" "MMMMMMMMMo
              MMMMM          "            " "MMMMMMMMMo
             oMMMM                          ""MMMMMMMMMo
            oMMMM         o         o         MMoMMMMMMM
            MMMM               o              "MMMMMMMMMM
           MMMM"     o    o             o     "MMMMMMMMMMo
         oMMMMM                                MMMMMMMMMMo
         MMM"MM                               "MMM"MMMMMMM
         MMMMMM           "      o   "         MMMMMMMMMMM
         "o  "ooo    o                     o o"MMMMMMMMoM"
        " o "o "MMo       "                o"  MMMMMMMM"
    o "o" o o "  MMMo                     o o""""MMMM"o" "
 " o "o " o o" "  MMMMoo         "       o "o M"" M "o " "
 "o o"  " o o" " " "MMMM"   o              M o "o" o" o" " o
 M  o M "  o " " " " MM""           o    oMo"o " o o "o " "o "
 o"  o " "o " " M " " o                MMMMo"o " o o o o" o o" "
 o" "o " o " " o o" M "oo         ooMMMMMMM o "o o o " o o o "
 M "o o" o" "o o o " o"oMMMMMMMMMMMMMMMMMMMo" o o "o "o o"
  "" "o"o"o"o o"o "o"o"oMMMMMMMMMMMMMMMMMMo"o"o "o o"oo"
        "" M Mo"o"oo"oM"" "               MMoM M M M
               """ """                      " """ "

*/