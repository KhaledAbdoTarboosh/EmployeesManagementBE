namespace EmployeesManagementBE.Helpers
{
    public static class BonusGenerator
    {

        public static double GetBonus(int salary,double departmentRatio,int evaluationRatio)
        {
            return Math.Max(salary * 12 * 15 / 100, salary * 12 * evaluationRatio * departmentRatio);
        }
        
    }
}
