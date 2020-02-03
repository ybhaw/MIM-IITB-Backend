namespace MIM_IITB.Data.ViewModels
{
    public class OuttakeBaseViewModel : ViewModelBase
    {
        public decimal Quantity { get; set; }
    }
    public class OuttakeViewModel : OuttakeBaseViewModel
    {
        public virtual FoodBaseViewModel Food { get; set; }
        public OuttakeBatchBaseViewModel OuttakeBatch { get; set; }
    }

    public class OuttakeWithFoodOnlyViewModel : OuttakeBaseViewModel
    {
        public virtual FoodBaseViewModel Food { get; set; }
    }
}