using Nix.Oop.Polymorphism;

Wv wv = new Wv();
wv.SetQuantity(100);
wv.SetWarranty(3);
wv.GetQuantity();
wv.GetFullInfo();
wv.GetFullInfo("silver");

Toyota toyota = new Toyota();
toyota.SetQuantity(150);
toyota.SetWarranty(5);
toyota.GetQuantity();
toyota.GetFullInfo();
toyota.GetFullInfo("blue");

Audi audi = new Audi();
audi.SetQuantity(88);
audi.SetWarranty(8);
audi.GetQuantity();
audi.GetFullInfo();
audi.GetFullInfo("A4");

Console.ReadKey();