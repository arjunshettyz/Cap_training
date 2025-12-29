class PolicyDirectory{
    private List<InsurancePolicy> store = new List<InsurancePolicy>();


    public InsurancePolicy this[int idx]
    {
        get {return store[idx]; }
    }

    public InsurancePolicy this[string name]
    {
        get
        {
            return store.FirstOrDefault(e => e.PolicyHolderName == name);
        }
    }
    public void AddData(InsurancePolicy obj)
    {
        store.Add(obj);
    }
}