namespace TaskManagerRoom308.DTO.GetAllUser
{
    public class MetaDataDTO
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalRow { get; set; } = 0;
        public int TotalPage { get; set; } = 0;
    }
}
