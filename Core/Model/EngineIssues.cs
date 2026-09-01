namespace Core.Model
{
    /// <summary>Не заводиться, не тягне, димить. Паливна, турбіна, ЕБУ двигуна.</summary>
    public class EngineIssues
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        /// <summary>1..5 — вага для формули рейтингу.</summary>
        public short Severity { get; set; }

        /// <summary>На якому пробігу зазвичай вилазить. null = не залежить.</summary>
        public int? TypicalMileageKm { get; set; }

        /// <summary>Роки випуску, яких стосується. null = всі.</summary>
        public short? AppliesYearFrom { get; set; }
        public short? AppliesYearTo { get; set; }

        /// <summary>Що робити при огляді — головне, що людина забере з собою.</summary>
        public string? HowToCheck { get; set; }

        /// <summary>Джерело, щоб через місяць перевірити дивну цифру.</summary>
        public string? SourceUrl { get; set; }

        /// <summary>Вичитано людиною. Невивірене на сайт не йде.</summary>
        public bool Verified { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Guid EngineId { get; set; }
        public Engine Engine { get; set; } = null!;
    }
}
