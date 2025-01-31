using System.Collections.Generic;

public static class SkillsDatabase
{
    public static List<Skill> GetAllSkills(List<Attribute> attributes, List<string> trainedSkills)
    {
        List<Skill> skills = new List<Skill>();

        // Habilidades principais
        skills.Add(new Skill("Acrobacia", false, attributes.Find(a => a.Name == "Dexterity"))); // Acrobacia (Des; penalidade por armadura)
        skills.Add(new Skill("Adestrar Animais", false, attributes.Find(a => a.Name == "Charisma"))); // Adestrar Animais (Car)
        skills.Add(new Skill("Atletismo", false, attributes.Find(a => a.Name == "Strength"))); // Atletismo (For; penalidade por armadura)
        skills.Add(new Skill("Cavalgar", false, attributes.Find(a => a.Name == "Dexterity"))); // Cavalgar (Des)
        skills.Add(new Skill("Concentração", false, attributes.Find(a => a.Name == "Wisdom"))); // Concentração (Sab)
        skills.Add(new Skill("Cura", false, attributes.Find(a => a.Name == "Wisdom"))); // Cura (Sab)
        skills.Add(new Skill("Decifrar Escrita", false, attributes.Find(a => a.Name == "Intelligence"))); // Decifrar Escrita (Int)
        skills.Add(new Skill("Diplomacia", false, attributes.Find(a => a.Name == "Charisma"))); // Diplomacia (Car)
        skills.Add(new Skill("Enganação", false, attributes.Find(a => a.Name == "Charisma"))); // Enganação (Car)
        skills.Add(new Skill("Furtividade", false, attributes.Find(a => a.Name == "Dexterity"))); // Furtividade (Des; penalidade por armadura)
        skills.Add(new Skill("Iniciativa", false, attributes.Find(a => a.Name == "Dexterity"))); // Iniciativa (Des)
        skills.Add(new Skill("Intimidar", false, attributes.Find(a => a.Name == "Charisma"))); // Intimidar (Car)
        skills.Add(new Skill("Percepção", false, attributes.Find(a => a.Name == "Wisdom"))); // Percepção (Sab)
        skills.Add(new Skill("Sabotagem", false, attributes.Find(a => a.Name == "Intelligence"))); // Sabotagem (Int)
        skills.Add(new Skill("Usar Instrumento Mágico", false, attributes.Find(a => a.Name == "Charisma"))); // Usar Instrumento Mágico (Car)
        skills.Add(new Skill("Vigor", false, attributes.Find(a => a.Name == "Constitution"))); // Vigor (Con)
        skills.Add(new Skill("Prestidigitação", false, attributes.Find(a => a.Name == "Dexterity")));

        // Habilidades secundárias
        skills.Add(new Skill("Atuações", false, attributes.Find(a => a.Name == "Charisma"))); // Atuações (Car)
        skills.Add(new Skill("Canto", false, attributes.Find(a => a.Name == "Charisma"))); // Canto (Car)
        skills.Add(new Skill("Comédia", false, attributes.Find(a => a.Name == "Charisma"))); // Comédia (Car)
        skills.Add(new Skill("Dança", false, attributes.Find(a => a.Name == "Charisma"))); // Dança (Car)
        skills.Add(new Skill("Instrumentos de corda", false, attributes.Find(a => a.Name == "Charisma"))); // Instrumentos de corda (Car)
        skills.Add(new Skill("Instrumentos de percussão", false, attributes.Find(a => a.Name == "Charisma"))); // Instrumentos de percussão (Car)
        skills.Add(new Skill("Instrumentos de sopro", false, attributes.Find(a => a.Name == "Charisma"))); // Instrumentos de sopro (Car)
        skills.Add(new Skill("Instrumentos de teclado", false, attributes.Find(a => a.Name == "Charisma"))); // Instrumentos de teclado (Car)
        skills.Add(new Skill("Oratória", false, attributes.Find(a => a.Name == "Charisma"))); // Oratória (Car)
        skills.Add(new Skill("Teatro", false, attributes.Find(a => a.Name == "Charisma"))); // Teatro (Car)
        skills.Add(new Skill("Conhecimento", false, attributes.Find(a => a.Name == "Intelligence"))); // Conhecimento (Int)
        skills.Add(new Skill("Arcano", false, attributes.Find(a => a.Name == "Intelligence"))); // Arcano (Int)
        skills.Add(new Skill("Masmorras", false, attributes.Find(a => a.Name == "Intelligence"))); // Masmorras (Int)
        skills.Add(new Skill("Natureza", false, attributes.Find(a => a.Name == "Intelligence"))); // Natureza (Int)
        skills.Add(new Skill("Religião", false, attributes.Find(a => a.Name == "Intelligence"))); // Religião (Int)
        skills.Add(new Skill("Social", false, attributes.Find(a => a.Name == "Intelligence"))); // Social (Int)
        skills.Add(new Skill("Os Planos", false, attributes.Find(a => a.Name == "Intelligence"))); // Os Planos (Int)
        skills.Add(new Skill("Falsificação", false, attributes.Find(a => a.Name == "Intelligence"))); // Falsificação (Int)
        skills.Add(new Skill("Ofícios", false, attributes.Find(a => a.Name == "Intelligence"))); // Ofícios (Int)
        skills.Add(new Skill("Alquimia", false, attributes.Find(a => a.Name == "Intelligence"))); // Alquimia (Int)
        skills.Add(new Skill("Armaduras", false, attributes.Find(a => a.Name == "Intelligence"))); // Armaduras (Int)
        skills.Add(new Skill("Armas", false, attributes.Find(a => a.Name == "Intelligence"))); // Armas (Int)
        skills.Add(new Skill("Itens Comuns", false, attributes.Find(a => a.Name == "Intelligence"))); // Itens Comuns (Int)
        skills.Add(new Skill("Mecanismos", false, attributes.Find(a => a.Name == "Intelligence"))); // Mecanismos (Int)

        foreach (string trainedSkill in trainedSkills)
        {
            Skill skill = skills.Find(s => s.SkillName == trainedSkill);
            if (skill != null)
            {
                skill.IsTrained = true;
            }
        }

        return skills;
    }
}
