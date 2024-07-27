namespace entities.Dtos
{
    public record BookDtoForInsertion : BookDtoForManipulation
    {
        public int CategoryId { get; set; }
    }

}
