namespace ComputerBuilder.DAL.Entities
{
    public class ManyBuildsToManyHwItemsEntity
    {
        public int HardwareItemId { get; set; }
        public HardwareItemEntity HardwareItem { get; set; }

        public int ComputerBuildId { get; set; }
        public ComputerBuildEntity ComputerBuild { get; set; }
    }
}
