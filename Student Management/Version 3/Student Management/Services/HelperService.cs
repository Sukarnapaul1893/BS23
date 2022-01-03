namespace Student_Management.Services;

public class HelperService
{
    private readonly UtilityService _utilityService;
    public HelperService()
    {
        _utilityService = new ();
    }
    public void HomeDisplay()
    {
        _utilityService.DisplayMessage("Enter corresponding integer of what you want to do!!!");
        _utilityService.DisplayMessage("1.  Insert Course", "2.  Insert Student", "3.  Insert Teacher");
        _utilityService.DisplayMessage("4.  See Course List", "5.  See Student List", "6.  See Teacher List");
        _utilityService.DisplayMessage("7.  Insert Student-Course", "8.  Student-Course Output");
        _utilityService.DisplayMessage("9.  Insert Teacher-Course", "10. Teacher-Course Output");
        _utilityService.DisplayMessage("11. Account LogIn");
    }
}