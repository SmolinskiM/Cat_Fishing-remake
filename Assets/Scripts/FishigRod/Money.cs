public class Money : SingletoneMonobehaviour<Money>
{
    private int moneyHaving;
    
    public int MoneyHaving { get { return moneyHaving; } }

    public void AddMoney(int moneyToAdd)
    {
        moneyHaving += moneyToAdd;
    }

    public void SubtractMoney(int moneyToSubtract)
    {
        moneyHaving -= moneyToSubtract;
    }
}
