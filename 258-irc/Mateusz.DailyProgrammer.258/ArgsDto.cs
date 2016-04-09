namespace Mateusz.DailyProgrammer._258
{
    public class ArgsDto
    {
        public string NickName { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }

        public ArgsDto(string nickName, string userName, string realName)
        {
            NickName = nickName;
            UserName = userName;
            RealName = realName;
        }
    }
}