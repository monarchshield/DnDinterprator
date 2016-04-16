using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace SpellInterpretator
{
    public enum SpellRange
    {
        Personal,
        Touch,
        Close,
        Medium,
        Long,
        Unlimited,
        NA,
    };
  
    public enum SavingThrow
    {
        NOPE,
        Will,
        Reflex,
        Fortitude
    };
    
    public enum CastingTime
    {
        SWIFT,
        STANDARD,
        FULLROUND
    };

   
    public enum SpellSchool
    {
        NOSCHOOL,
        ABJURATION,
        CONJURATION,
        DIVINATION,
        ENCHANTMENT,
        EVOCATION,
        ILLUSION,
        NECROMANCY,
        TRANSMUTATION
    };

    public struct Spell
    {
        public string _SpellName;
        public string _SpellDescription;
        public SpellSchool _SpellSchool;
        public int _SpellLevel;
        public string _SpellComponents;
        public CastingTime _SpellCastingTime;
        public SpellRange _SpellRange;
        public int _AreaOfEffect;
    
        public string _SpellDuration;
        public SavingThrow _Savingthrow;
       // public SpellEffectAreaType _AreaType;
        public string _AreaType;
        public string _DefaultSpellRange;

    };


    class SpellCreator
    {
        public Spell m_SpellInfo;

       
        public SpellCreator()
        {
               
        }

        public void CreateSpell()
        {

           string response;


            #region Author
            Console.WriteLine("-------------------------------------------------------\nAuthor: Anthony Bogli \nDescription: Used for Creating Spell Macros \nCreated Date: 6th of April 2016 \nGithub: www.github.com/monarchshield \n \nShortcuts: \n!CL for casterlevel \n!CLMAX99 for casterlevel up to max of 99 \n-------------------------------------------------------\n");
            #endregion


            #region Spell Name
            Console.WriteLine("Enter In the Spell Name");
            m_SpellInfo._SpellName = Console.ReadLine();
            Console.WriteLine();
            #endregion

            # region SpellDescription
            Console.WriteLine("Enter In the Spells Description");

            #region Shortcuts
            response = Console.ReadLine();
            response.Replace("!CL", "[[@{casterlevel}]]");
            string val = response.Substring(response.IndexOf("!CLMAX") + 6, 2);
            response.Replace("!CLMAX", "[[({@{casterlevel}," + val + "}dh1)]]");
            #endregion

            m_SpellInfo._SpellDescription = response;
            Console.WriteLine();
            #endregion

            #region SpellSchool

            Console.WriteLine("Spells Range: (A)bjuration, (C)onjuration, (D)ivination, Enc(H)antment \n Evocation ,(I)llusion, (N)ecromancy,(T)ransmutation \n  1 For none \n");
            response = Console.ReadLine();


            
            switch (response)
            {
                case "A": m_SpellInfo._SpellSchool = SpellSchool.ABJURATION; break;
                case "C": m_SpellInfo._SpellSchool = SpellSchool.CONJURATION; break;
                case "D": m_SpellInfo._SpellSchool = SpellSchool.DIVINATION; break;
                case "H": m_SpellInfo._SpellSchool = SpellSchool.ENCHANTMENT; break;
                case "E": m_SpellInfo._SpellSchool = SpellSchool.EVOCATION; break;
                case "I": m_SpellInfo._SpellSchool = SpellSchool.ILLUSION; break;
                case "N": m_SpellInfo._SpellSchool = SpellSchool.NECROMANCY; break;
                case "T": m_SpellInfo._SpellSchool = SpellSchool.TRANSMUTATION; break;

                default: m_SpellInfo._SpellSchool = SpellSchool.NOSCHOOL; break;
            }
            Console.WriteLine();

            #endregion

            #region Spell Level
            Console.WriteLine("What Level is the spell (this effects the saving throw)");
            m_SpellInfo._SpellLevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            #endregion

            #region Spell Components
            Console.WriteLine("Enter In the Spells Components");
            m_SpellInfo._SpellComponents = Console.ReadLine();
            Console.WriteLine();
            #endregion

            #region casting time
            Console.WriteLine("How long to cast: (I)nstant, (S)tandard, (F)ull round");  
            response = Console.ReadLine();
            switch (response)
            {
                case "I": m_SpellInfo._SpellCastingTime = CastingTime.SWIFT; break;
                case "S": m_SpellInfo._SpellCastingTime = CastingTime.STANDARD; break;
                case "F": m_SpellInfo._SpellCastingTime = CastingTime.FULLROUND; break;
                default:
                    break;
            }
            Console.WriteLine();

            #endregion

            #region Spell Range
            Console.WriteLine("Spells Range: (P)ersonal, (T)ouch, (C)lose, (M)edium, (L)ong, (U)nlimited, (O)ther");
            response = Console.ReadLine();
            Console.WriteLine("");;


            switch (response)
            {
                case "P": m_SpellInfo._SpellRange = SpellRange.Personal; break;
                case "T": m_SpellInfo._SpellRange = SpellRange.Touch; break;
                case "C": m_SpellInfo._SpellRange = SpellRange.Close; break;
                case "M": m_SpellInfo._SpellRange = SpellRange.Medium; break;
                case "L": m_SpellInfo._SpellRange = SpellRange.Long; break;
                case "U": m_SpellInfo._SpellRange = SpellRange.Unlimited; break;

                default:
                    {
                        Console.WriteLine("What is Spells Distance");
                        m_SpellInfo._DefaultSpellRange = Console.ReadLine();
                        m_SpellInfo._SpellRange = SpellRange.NA;
                    }
                    break;
            }
            Console.WriteLine();
            #endregion

            #region Area of Effect
           Console.WriteLine("Enter a spells area of effect Type 0 if none or 1 If Cone \n 2 If Cube, 3 if Radius, 4 if Line");
           m_SpellInfo._AreaOfEffect = Convert.ToInt32(Console.ReadLine());

            if (m_SpellInfo._AreaOfEffect > 0 && m_SpellInfo._AreaOfEffect < 5)
            {
                Console.WriteLine("Enter how big the effect is e.g 30 or [[!CL * 2]] etc");
                response = Console.ReadLine();

                #region Shortcuts
                response.Replace("!CL", "[[@{casterlevel}]]");
                string val = response.Substring(response.IndexOf("!CLMAX") + 6, 2);
                response.Replace("!CLMAX", "[[({@{casterlevel}," + val + "}dh1)]]");
                #endregion
            }

            switch (m_SpellInfo._AreaOfEffect)
            {
                case 0: m_SpellInfo._AreaType = "None"; break;
                case 1: m_SpellInfo._AreaType = response + "ft Cone"; break;
                case 2: m_SpellInfo._AreaType = response + "ft Cube"; break;
                case 3: m_SpellInfo._AreaType = response + "ft Circle"; break;
                case 4: m_SpellInfo._AreaType = response + "Ft Line"; break;
                default: m_SpellInfo._AreaType =" None"; break;
            }

            Console.WriteLine();
            #endregion

            #region Spell Duration
           
            Console.WriteLine("Spells Duration: (I)nstantaneous, (C)oncentration, (R)ound/Level, (M)inute/level, (T)en minute/level (H)our/level, (D)ay/level, (N)oneofabove");
            response = Console.ReadLine();
            Console.WriteLine("");;


            switch (response)
            {
                case "I": m_SpellInfo._SpellDuration = "Instantaneous"; break;
                case "C":
                    {
                      
                        Console.WriteLine("Any bonuses like Concentration +1 etc enter 0 for none");
                        response = Console.ReadLine();       
                        m_SpellInfo._SpellDuration= "[[1d20 + [[@{concentration}]]" + response + "]]";
                    }
                    break;

                case "R": m_SpellInfo._SpellDuration = "[[[[@{casterlevel}]]]] rounds"; break;
                case "M": m_SpellInfo._SpellDuration = "[[[[@{casterlevel}]]]] minutes"; break;
                case "T": m_SpellInfo._SpellDuration = "[[[[@{casterlevel}]] * 10]] minutes"; break;
                case "H": m_SpellInfo._SpellDuration = "[[[[@{casterlevel}]]]] hours"; break;
                case "D": m_SpellInfo._SpellDuration = "[[[[@{casterlevel}]]]] days"; break;
                case "N":
                    {
                        Console.WriteLine("Well your gonna have to DIY it for now until this is added type in the macro code e.g \n [[[[@{casterlevel}]]]] that retrieves caster level \n or [[1d20]] rolls a d20 or [[[[1d20]]+ 2]] rolls a d20 + 2) \n");
                        response = Console.ReadLine();

                        #region Shortcuts
                        response.Replace("!CL", "[[@{casterlevel}]]");
                        string val = response.Substring(response.IndexOf("!CLMAX") + 6, 2);
                        response.Replace("!CLMAX", "[[({@{casterlevel}," + val + "}dh1)]]");
                        #endregion

                        m_SpellInfo._SpellDuration = response;
                    }
                    break;


                default: m_SpellInfo._SpellSchool = SpellSchool.NOSCHOOL; break;
            }
            Console.WriteLine();
            #endregion

            #region SaveThrowTypes
 
            Console.WriteLine("What is the Saving throw type: (N)one, (W)ill, (R)eflex, (F)ortitude");
            response = Console.ReadLine();

            switch (response)
            {
                case "N": m_SpellInfo._Savingthrow = SavingThrow.NOPE; break;
                case "W": m_SpellInfo._Savingthrow = SavingThrow.Will; break;
                case "R": m_SpellInfo._Savingthrow = SavingThrow.Reflex; break;
                case "F": m_SpellInfo._Savingthrow = SavingThrow.Fortitude; break;
                default:
                   Console.WriteLine("That is not a saving throw type scrub");
                    break;
            }

            Console.WriteLine();
            #endregion
        }

        public void SaveSpell()
        {
           
            string Macrostring = "&{template:DnD35StdRoll}{{spellflag=true}}";
            Macrostring += "{{name= @{character_name} casts " + m_SpellInfo._SpellName + "}}";
            Macrostring += "{{School:= " + m_SpellInfo._SpellSchool.ToString() + "}}";

            #region SpellCastingTIme
            switch (m_SpellInfo._SpellCastingTime)
            {
                case CastingTime.SWIFT:
                    Macrostring += "{{Casting Time:= Immediete}}";
                    break;
                case CastingTime.STANDARD:
                    Macrostring += "{{Casting Time:= Standard}}";
                    break;
                case CastingTime.FULLROUND:
                    Macrostring += "{{Casting Time:= fullRound}}";
                    break;

                default:
                    break;
            }
            #endregion  

            #region SpellRange
            switch (m_SpellInfo._SpellRange)
            {
                case SpellRange.Personal:
                    Macrostring += "{{Range:= Personal}}";
                    break;

                case SpellRange.Touch:
                    Macrostring += "{{Range:= Touch}}";
                    break;

                case SpellRange.Close:
                    Macrostring += "{{Range:= [[[[[[floor([[[[@{casterlevel}]] /2]]) * 5]] + 25]]]] ft }}";
                    break;
                case SpellRange.Medium:
                    Macrostring += "{{Range:= [[[[[[floor([[[[@{casterlevel}]]]]) * 10]] + 100]]]] ft }}";
                    break;
                case SpellRange.Long:
                    Macrostring += "{{Range:= [[[[[[floor([[[[@{casterlevel}]]]]) * 40]] + 400]]]] ft }}";
                    break;
                case SpellRange.Unlimited:
                    Macrostring += "{{Range:= Unlimited}}";
                    break;

                case SpellRange.NA:
                    Macrostring += "{{Range:= " + m_SpellInfo._DefaultSpellRange.ToString() + "}}";
                    break;

                default:
                    break;
            }
            #endregion

            Macrostring += "{{Components:=" + m_SpellInfo._SpellComponents + "}}";

            Macrostring += "{{Duration:=" + m_SpellInfo._SpellDuration + "}}";


            #region SavingThrow

            string _Savetype;
            switch (m_SpellInfo._Savingthrow)
            {
                case SavingThrow.NOPE: _Savetype = "None:"; break;
                case SavingThrow.Will: _Savetype = "Will:"; break;
                case SavingThrow.Reflex: _Savetype = "Reflex:"; break;
                case SavingThrow.Fortitude: _Savetype = "Fortitude:"; break;

                default:
                    _Savetype = "None:";
                    break;
            }

            if (m_SpellInfo._Savingthrow != 0)
            {
                switch (m_SpellInfo._SpellSchool)
                {
                    case SpellSchool.NOSCHOOL:
                        Macrostring += "{{Saving Throw" + _Savetype + "=" + "[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]}}";
                        break;
                    case SpellSchool.ABJURATION:
                        Macrostring += "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-abjuration}]]]]" + "}}";
                        break;
                    case SpellSchool.CONJURATION:
                        Macrostring += "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-conjuration}]]]]" + "}}";
                        break;
                    case SpellSchool.DIVINATION:
                        Macrostring += "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-divination}]]]]" + "}}";
                        break;
                    case SpellSchool.ENCHANTMENT:
                        Macrostring += "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-enchantment}]]]]" + "}}";
                        break;
                    case SpellSchool.EVOCATION:
                        Macrostring += "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-evocation}]]]]" + "}}";
                        break;
                    case SpellSchool.ILLUSION:                                                                 
                        Macrostring += "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-illusion}]]]]" + "}}";
                        break;
                    case SpellSchool.NECROMANCY:                                                               
                        Macrostring += "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-necromancy}]]]]" + "}}";
                        break;
                    case SpellSchool.TRANSMUTATION:                                                            
                        Macrostring +=  "{{Saving Throw " + _Savetype + "=" + "[[[[@{spelldc" + m_SpellInfo._SpellLevel.ToString() + "}]]" + "+" + "[[@{sf-transmutation}]]]]" + "}}";
                        break;
                }
            }

         #endregion SavingThrow
            Macrostring += "{{Description:=" + m_SpellInfo._SpellDescription + "}}";


            System.IO.File.WriteAllText(m_SpellInfo._SpellName, Macrostring);


        }
    }
}
