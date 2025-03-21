using System;

public class Money : SingletoneMonobehaviour<Money>
{
    public Action onMoneyChange;
    private int moneyHaving = 10000;
    
    public int MoneyHaving { get { return moneyHaving; } }

    public void AddMoney(int moneyToAdd)
    {
        moneyHaving += moneyToAdd;
        onMoneyChange?.Invoke();
    }

    public void SubtractMoney(int moneyToSubtract)
    {
        moneyHaving -= moneyToSubtract;
        onMoneyChange?.Invoke();
    }
}
