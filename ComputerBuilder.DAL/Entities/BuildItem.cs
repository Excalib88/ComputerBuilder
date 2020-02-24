namespace ComputerBuilder.DAL.Entities
{
    public class BuildItem
    {
        public int HardwareItemId { get; set; }
        public HardwareItem HardwareItem { get; set; }

        public int ComputerBuildId { get; set; }
        public ComputerBuild ComputerBuild { get; set; }
    }
}
