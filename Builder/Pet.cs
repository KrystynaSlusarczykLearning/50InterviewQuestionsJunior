namespace Builder
{
    class Pet
    {
        //public Pet() //only for object initializer
        //{

        //}

        public Pet(string type, string officialName, string nickname, string motherName, string fatherName, string breedingCompanyName)
        {
            Type = type;
            OfficialName = officialName;
            Nickname = nickname;
            MotherName = motherName;
            FatherName = fatherName;
            BreedingCompanyName = breedingCompanyName;
        }

        public string Type { get; }
        public string OfficialName { get; }
        public string Nickname { get; }
        public string MotherName { get; }
        public string FatherName { get; }
        public string BreedingCompanyName { get; }

        public class Builder
        {
            private string _type;
            private string _officialName;
            private string _nickname;
            private string _motherName;
            private string _fatherName;
            private string _breedingCompanyName;

            public Builder WithType(string type)
            {
                _type = type;
                return this;
            }

            public Builder WithOfficialName(string officialName)
            {
                _officialName = officialName;
                return this;
            }

            public Builder WithNickname(string nickname)
            {
                _nickname = nickname;
                return this;
            }

            public Builder WithMotherName(string motherName)
            {
                _motherName = motherName;
                return this;
            }

            public Builder WithFatherName(string fatherName)
            {
                _fatherName = fatherName;
                return this;
            }

            public Builder WithBreedingCompanyName(string breedingCompanyName)
            {
                _breedingCompanyName = breedingCompanyName;
                return this;
            }

            public Pet Build()
            {
                return new Pet(_type, _officialName, _nickname, _motherName, _fatherName, _breedingCompanyName);
            }
        }
    }
}
