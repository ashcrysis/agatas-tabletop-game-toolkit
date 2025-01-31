# Agata's Tabletop Game Toolkit

## Overview

Welcome to my little project!
This project is designed to simplify and speed up the development of tabletop-like games in Unity. Whether you are building a digital version of a board game or creating your own tabletop experience, this toolkit provides some essential components and features.

Currently, I am developing this toolkit for my own games, not using any rpg system exactly as reference, since i want it to be able to adapt to other genres, and it’s designed as a modular code-only project. This allows easy integration into other games just by importing the toolkit. I thought it would be a good idea to open-source it, so others can benefit and contribute as well.

Feel free to contribute to the project by opening pull requests or reporting issues!

## Features

- **Dice Rolling System**: Roll virtual dice with customizable dice types. You can specify the number of dice, sides, and other parameters to create various rolling mechanics for your game.
- **Player Management**: Handle player classes, races, stats, and attributes. Easily define and manage character classes and races with ScriptableObjects, enabling more dynamic character customization.
- **Technique System**: Implement various techniques like attacks, healing, buffs, debuffs, and special abilities. This system allows you to define techniques with attributes such as mana cost, cooldown time, and class/race exclusivity.
- **TechniqueData Management**: Manage the techniques available to the player, including unlocking new techniques, using them, and checking if new techniques can be learned based on the player's stats.

---

## Installation

To get started follow these steps:

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/ashcrysis/TabletopGameToolkit.git
   ```

2. **Open it in Unity**:

   - Open Unity and load the project folder you just cloned.

3. **Make Your Changes and Open a PR**:
   - If you make improvements or fixes, feel free to create a pull request. Contributions are always welcome!

---

## Usage Example

### Dice Rolling System

The Dice Rolling System allows you to roll customizable dice types. Here's an example of how you can use it in your game:

```csharp
// Roll 2 6-sided dices
DiceRoller diceRoller = new DiceRoller("2d6");
var result = diceRoller.RollDice();
Debug.Log("Dice rolled: " + result.total);
```

### Character Class

The `CharacterClass` is a ScriptableObject that holds information about a character's class, such as attributes, skills, and modifiers.

In the Unity Editor, you can now create new character classes from the `Create` menu. Example of creating a "Warrior" class:

- **ClassName**: Warrior
- **Description**: A strong and resilient fighter.
- **Attributes**: Modify `Strength` and `Constitution` for bonuses.

### Character Race

Similar to `CharacterClass`, `CharacterRace` is a ScriptableObject that defines the racial attributes and skills available to characters based on their race.

Example of creating an "Elf" race:

- **RaceName**: Elf
- **Description**: A graceful and intelligent race, skilled in magic.
- **Attributes**: Boost `Dexterity` and `Intelligence`.

You can create new races in Unity by selecting `Create > RPG > Character Race` and adjusting the values in the inspector.

### Technique System Documentation

---

#### **Technique Class**

The `Technique` class represents a skill or ability in the game that a player can use. This can include attacks, healing, buffs, debuffs, and special abilities. Each technique has various attributes like mana cost, stamina cost, cooldown time, dice rolls for damage/heal, and conditions for when the technique can be used (such as level, class, race, etc.), keep in mind some of them are still not being used, still are going to be implemented.

##### **Properties**

- `techniqueName` (string): Name of the technique.
- `description` (string): A description of what the technique does.
- `techniqueType` (TechniqueType): The type of the technique (e.g., Attack, Heal).
- `damageType` (damageType): Specifies the damage type (e.g., Fire, Magic, etc.).
- `requiredLevel` (int): The level required to use the technique.
- `manaCost` (int): The amount of mana required to use the technique.
- `staminaCost` (int): The amount of stamina required to use the technique.
- `isClassExclusive` (bool): Whether the technique is exclusive to a specific class.
- `classRequirement` (string): The class that must be met for this technique to be used.
- `isRaceExclusive` (bool): Whether the technique is exclusive to a specific race.
- `raceRequirement` (string): The race that must be met for this technique to be used.
- `AttributeRoll` (string): The attribute used in a dice roll to determine success.
- `SkillRoll` (string): The skill used for the dice roll (if applicable).
- `diceDT` (int): The minimum required roll for success.
- `cooldownTime` (float): The time in seconds before the technique can be used again.
- `lastUsedTime` (float): Stores the last time the technique was used.
- `dice` (string): The dice format used for rolling damage or healing (e.g., `1d6`, `2d8`).

##### **Methods**

- `CanUse()`: Returns `true` if the technique can be used (i.e., cooldown has elapsed).
- `SyncVariables(TechniqueData tech)`: Syncs the technique's variables from a `TechniqueData` object.
- `Setup()`: Loads the `TechniqueData` for the technique from resources and syncs the variables.
- `Use(PlayerCharacter player)`: Performs the technique using the player's stats, rolling the required dice, and checking conditions (e.g., cooldown, attribute rolls).
- `UseSkill(PlayerCharacter player)`: A virtual method that is overridden by specific techniques to implement their unique functionality.

---

#### **TechniqueData Class**

The `TechniqueData` class holds the static data for each technique. It is used as the template from which techniques are set up and executed in the game.

#### **TechniqueDataManager Class**

The `TechniqueDataManager` class is responsible for managing the techniques available to the player, including unlocking new techniques, using them, and checking if new techniques can be learned.

##### **Properties**

- `knownTechniqueDatas` (List<Technique>): A list of techniques that the player has already learned.
- `allTechniqueDatas` (List<Technique>): A list of all available techniques in the game.
- `playerStats` (PlayerCharacter): The player's character stats.
- `techniqueManager` (TechniqueDataManager): A reference to the `TechniqueDataManager` component.

##### **Methods**

- `UnlockStartingTechniqueDatas()`: Unlocks the techniques that the player can learn at the start based on their level, class, and race.
- `CanLearnTechniqueData(Technique techniqueData)`: Checks if a technique can be learned by the player based on their stats.
- `LearnTechniqueData(Technique techniqueData)`: Unlocks a technique for the player.
- `UseTechniqueData(string techniqueDataName)`: Uses a technique by its name.
- `CheckForNewUnlocks()`: Checks if any new techniques should be unlocked based on the player's current stats.
- `UseFirstKnownTechnique()`: Uses the first known technique in the `knownTechniqueDatas` list.

---

#### **Example Technique**

The `ExampleTechnique` class is a specific implementation of the `Technique` class. It overrides the `UseSkill` method to provide specific behavior for a technique, such as rolling damage or healing based on the dice roll.

##### **Methods**

- `UseSkill(PlayerCharacter player)`: Performs the specific logic for this technique, rolling the appropriate dice and printing the results for damage or healing.

---

### **Technique Example Implementation**

Here’s an example of how a `Technique` might be implemented and used:

```csharp
public class FireballTechnique : Technique
{
    public override void UseSkill(PlayerCharacter player)
    {
        var roll = player.gameObject.GetComponent<DiceRoller>().RollDice(dice);
        if (techniqueType == TechniqueType.Attack)
        {
            Debug.Log($"{player.CharacterName} used {techniqueName} and dealt {roll.total} total damage! ({roll.rollResults})");
        }
        else if (techniqueType == TechniqueType.Heal)
        {
            Debug.Log($"{player.CharacterName} used {techniqueName} and healed {roll.total} HP! ({roll.rollResults})");
        }
    }
}
```

In this example, the `FireballTechnique` extends `Technique` and overrides `UseSkill` to handle rolling dice for an attack or healing.

---

## Contributing

This project is open-source, and contributions are welcome! Here’s how you can help:

1. **Make Changes**: Create a new branch, make your changes, and commit them.
2. **Push Your Changes**: Push your changes back to your forked repository.
3. **Open a Pull Request**: Open a pull request to propose your changes.

I encourage you to submit bug fixes, improvements, and feature requests.

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for more details.

## Credits

- Developed by: **[Agata Asher Martins](https://ashcrysis.itch.io/)**
- Assets: Using **Elthen's** free asset packs to create the example scene.  
  You can find them [here on itch.io](https://elthen.itch.io/).

## Contact

For any questions, feel free to reach out via email or open an issue on the repository.
