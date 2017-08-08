using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyeongCsharp
{
    public struct 혀엉명령어 { public char 명령; public int 글자길이, 줄임표길이; public string 하트구역; }
    
    public class Parser
    {
        const string 점3개 = "…⋯⋮";
        public string 혀엉코드 = "";
        const string 점 = ".";
        const string 하트 = "♥❤💕💖💗💘💙💚💛💜💝";
        const string 명령어 = "형항핫흣흡흑혀하흐";
        public List<혀엉명령어> 명령어해석()
        {
            List<혀엉명령어> 해석된명령어들 = new List<혀엉명령어>();
            int 탐색중인위치 = 0;
            while (탐색중인위치 < 혀엉코드.Length)
            {
                혀엉명령어 탐색중인명령어 = new 혀엉명령어();
                try
                {
                    한글글자해석단계(ref 탐색중인위치, ref 탐색중인명령어);
                    if (탐색중인위치 < 혀엉코드.Length)
                    {
                        if (말줄임표해석단계(ref 탐색중인위치, ref 탐색중인명령어))
                        {
                            하트구역해석단계(ref 탐색중인위치, ref 탐색중인명령어);
                        }
                    }
                }
                finally
                {
                    해석된명령어들.Add(탐색중인명령어);
                }
            }

            return 해석된명령어들;
        }
        void 한글글자해석단계(ref int 탐색할위치, ref 혀엉명령어 탐색할명령어)//TODO : 해석하지못하는 문자로 처리기능 구현
        {
            int 글자길이 = 1;
            switch (혀엉코드[탐색할위치])
            {
                case '형':
                    탐색할명령어.명령 = '형';
                    탐색할명령어.글자길이 = 글자길이;
                    탐색할위치++;
                    break;
                case '항':
                    탐색할명령어.명령 = '항';
                    탐색할명령어.글자길이 = 글자길이;
                    탐색할위치++;
                    break;
                case '핫':
                    탐색할명령어.명령 = '핫';
                    탐색할명령어.글자길이 = 글자길이;
                    탐색할위치++;
                    break;
                case '흣':
                    탐색할명령어.명령 = '흣';
                    탐색할명령어.글자길이 = 글자길이;
                    탐색할위치++;
                    break;
                case '흡':
                    탐색할명령어.명령 = '흡';
                    탐색할명령어.글자길이 = 글자길이;
                    탐색할위치++;
                    break;
                case '흑':
                    탐색할명령어.명령 = '흑';
                    탐색할명령어.글자길이 = 글자길이;
                    탐색할위치++;
                    break;
                case '혀':
                    while (혀엉코드[탐색할위치] != '엉')
                    {
                        if (완성형한글인거냐(혀엉코드[탐색할위치]))
                            글자길이++;
                        탐색할위치++;
                    }
                    탐색할명령어.명령 = '형';
                    탐색할명령어.글자길이 = 글자길이;
                    탐색할위치++;
                    break;
                case '하':
                    bool 끝자리찾았니 = false;
                    while (!끝자리찾았니)
                    {
                        switch (혀엉코드[탐색할위치])
                        {
                            case '앙':
                                탐색할명령어.명령 = '항';
                                탐색할명령어.글자길이 = 글자길이;
                                끝자리찾았니 = true;
                                break;
                            case '앗':
                                탐색할명령어.명령 = '핫';
                                탐색할명령어.글자길이 = 글자길이;
                                끝자리찾았니 = true;
                                break;
                            default:
                                if (완성형한글인거냐(혀엉코드[탐색할위치]))
                                    글자길이++;
                                탐색할위치++;
                                break;
                        }
                    }
                    탐색할위치++;
                    break;
                case '흐':
                    bool 끝자리찾았니2 = false;
                    while (!끝자리찾았니2)
                    {
                        switch (혀엉코드[탐색할위치])
                        {
                            case '읏':
                                탐색할명령어.명령 = '흣';
                                탐색할명령어.글자길이 = 글자길이;
                                끝자리찾았니2 = true;
                                break;
                            case '읍':
                                탐색할명령어.명령 = '흡';
                                탐색할명령어.글자길이 = 글자길이;
                                끝자리찾았니2 = true;
                                break;
                            case '윽':
                                탐색할명령어.명령 = '흑';
                                탐색할명령어.글자길이 = 글자길이;
                                끝자리찾았니2 = true;
                                break;
                            default:
                                if (완성형한글인거냐(혀엉코드[탐색할위치]))
                                    글자길이++;
                                탐색할위치++;
                                break;
                        }
                    }
                    탐색할위치++;
                    break;
                default:
                    탐색할위치++;
                    한글글자해석단계(ref 탐색할위치, ref 탐색할명령어);
                    break;
            }
        }
        bool 말줄임표해석단계(ref int 탐색할위치, ref 혀엉명령어 탐색할명령어)
        {
            int 위치임시값 = 탐색할위치;
            if (탐색할위치 >= 혀엉코드.Length)
            {
                return false;
            }
            if (하트.Any(s => 혀엉코드[위치임시값] == s)|| 혀엉코드[위치임시값] == '?'|| 혀엉코드[위치임시값] == '!')
                return true;
            else if (명령어.Any(s => 혀엉코드[위치임시값] == s))
                return false;
            else if (혀엉코드[위치임시값] == '.')
            {
                탐색할명령어.줄임표길이++;
                탐색할위치++;
            }
            else if (점3개.Any(s => 혀엉코드[위치임시값] == s))
            {
                탐색할명령어.줄임표길이+=3;
                탐색할위치++;
            }
            else
            {
                탐색할위치++;
            }
            return 말줄임표해석단계(ref 탐색할위치, ref 탐색할명령어);
        }
        void 하트구역해석단계(ref int 탐색할위치, ref 혀엉명령어 탐색할명령어)
        {

        }
        bool 완성형한글인거냐(char cStr)
        {
            if (cStr >= '\xAC00' && cStr <= '\xD7AF')
                return true;
            else
                return false;
        }
    }
}
