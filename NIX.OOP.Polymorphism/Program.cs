using Nix.Oop.Polymorphism;

Car wv = new Wv();
wv.SetQuantity(100);
wv.SetWarranty(3);
wv.GetQuantity();
wv.GetFullInfo();
((Wv)wv).GetFullInfo("silver");

Car toyota = new Toyota();
toyota.SetQuantity(150);
toyota.SetWarranty(5);
toyota.GetQuantity();
toyota.GetFullInfo();
((Toyota)toyota).GetFullInfo("blue");

Car audi = new Audi();
audi.SetQuantity(88);
audi.SetWarranty(8);
audi.GetQuantity();
audi.GetFullInfo();
((Wv)audi).GetFullInfo("A4");

Console.ReadKey();