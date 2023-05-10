namespace DesignPattern.ChainOfResponsibility.Constants
{
    public static class Messages
    {
        public static string AmountPaid = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar ödendi.";
        public static string TreasurerCantPay = "Para çekme tutarı veznedarın günlük ödeyebileceği limiti aştığı için işlem şube müdür yardımcısına yönlendirildi.";
        public static string ManagerAssistantCantPay = "Para çekme tutarı şube müdür yardımcısının günlük ödeyebileceği limiti aştığı için işlem şube müdürüne yönlendirildi.";
        public static string ManagerCantPay = "Para çekme tutarı şube müdürünün günlük ödeyebileceği limiti aştığı için işlem bölge direktörüne yönlendirildi.";
        public static string AreaDirectorCantPay = "Para çekme tutarı bölge direktörünün günlük ödeyebileceği limiti aştığı için işlem gerçekleştirilemedi. Müşterinin günlük maksimum çekebileceği tutar 400.000 TL olup, daha fazlası için birden fazla gün şubeye gelmesi gerekli.";
    }
}
