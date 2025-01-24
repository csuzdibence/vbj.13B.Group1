using InterfaceDemo;

// Ugyanúgy működik mint egy másik típus
IMakeSound[] soundMakers = new IMakeSound[4];

for (int i = 0; i < 4; i++)
{
    if (i < 2)
    {
        soundMakers[i] = new Cat();
    }
    else
    {
        soundMakers[i] = new Dog();
    }
}

foreach (var soundMaker in soundMakers)
{
    soundMaker.MakeSound();
}