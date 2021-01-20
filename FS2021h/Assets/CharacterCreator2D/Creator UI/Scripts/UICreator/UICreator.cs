using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCreator2D.UI
{
    public class UICreator : MonoBehaviour
    {
        /// <summary>
        /// CharacterViewer displayed by this UICreator.
        /// </summary>
        [Tooltip("CharacterViewer displayed by this UICreator")]
        public CharacterViewer character;

        /// <summary>
        /// UIColor managed by this UICreator.
        /// </summary>
        [Tooltip("UIColor managed by this UICreator")]
        public UIColor colorUI;

        /// <summary>
        /// RuntimeDialog used by this UICreator.
        /// </summary>
        [Tooltip("RuntimeDialog used by this UICreator")]
        public RuntimeDialog dialog;

        /// <summary>
        /// JSON file location of this character in Build mode.
        /// </summary>
        [Tooltip("JSON file location of this character in build mode")]
        public string JSONRuntimePath;

        private List<Transform> _menus;
        private List<Transform> _partmenus;
        private Dictionary<SlotCategory, List<Part>> _availparts = new Dictionary<SlotCategory, List<Part>>();
        private Part nullpart = null;
        private bool _processing = false;

        private readonly Dictionary<SlotCategory, int> _RANDSETTINGS = new Dictionary<SlotCategory, int>()
        {
            { SlotCategory.Armor, 100 },
            { SlotCategory.Boots, 100 },
            { SlotCategory.Cape, 40 },
            { SlotCategory.Ear, 40 },
            { SlotCategory.Eyebrow, 98 },
            { SlotCategory.Eyes, 100 },
            { SlotCategory.FacialHair, 50 },
            { SlotCategory.Gloves, 60 },
            { SlotCategory.Hair, 90 },
            { SlotCategory.Helmet, 70 },
            { SlotCategory.MainHand, 50 },
            { SlotCategory.Mouth, 100 },
            { SlotCategory.Nose, 100 },
            { SlotCategory.OffHand, 50 },
            { SlotCategory.Pants, 100 },
            { SlotCategory.SkinDetails, 40 },
            { SlotCategory.Skirt, 20 },
        };

        void Awake()
        {
            _processing = false;
            BodyTypeGroup bodygroup = this.transform.GetComponentInChildren<BodyTypeGroup>(true);
            bodygroup.Initialize();
            PartGroup[] partgroups = this.transform.GetComponentsInChildren<PartGroup>(true);
            foreach (PartGroup g in partgroups)
                g.Initialize();
            _menus = new List<Transform>();
            foreach (Transform child in this.transform)
                if (child.name != "Top Menu" && child.name != "Bottom Menu" && child.name != "Parts")
                _menus.Add(child);
            _partmenus = new List<Transform>();
            Transform partsParent = this.transform.Find("Parts");
            foreach (Transform child in partsParent)
                _partmenus.Add(child);
        }

        public void CloseAllMenus () 
        {
            if (_menus != null)
            foreach (Transform t in _menus) 
            {
                t.gameObject.SetActive(false);
            }
            if (_partmenus != null)
            foreach (Transform t in _partmenus)
            {
                t.gameObject.SetActive(false);
            }
        }

        public void OpenMenu (GameObject open)
        {
            CloseAllMenus();
            open.SetActive(true);
        }

        /// <summary>
        /// [EDITOR] Save character as a prefab in desired path.
        /// </summary>
        public void SaveCharacterAsPrefab()
        {
            if (this.character == null || _processing)
                return;

            StartCoroutine("ie_savecharaasprefab");
        }

        IEnumerator ie_savecharaasprefab()
        {
            _processing = true;
            yield return null;
#if UNITY_EDITOR
            string path = CharacterUtils.ShowSaveFileDialog("Save Character", "New Character", "prefab");
            if (!string.IsNullOrEmpty(path))
            {
                CharacterViewer tcharacter = CharacterUtils.SpawnCharacter(this.character, path);
                yield return null;
                yield return null;
                CharacterUtils.SaveCharacterToPrefab(tcharacter, path);
                yield return null;
                yield return null;
                Destroy(tcharacter.gameObject);
                dialog.DisplayDialog("Save Character", "'" + tcharacter.name + "' is saved");
            }
#endif
            _processing = false;
        }

        /// <summary>
        /// [EDITOR] Load character from a prefab.
        /// </summary>
        public void LoadCharacterFromPrefab()
        {
            _processing = true;
#if UNITY_EDITOR
            string path = CharacterUtils.ShowOpenFileDialog("Load Character", "prefab");
            if (!string.IsNullOrEmpty(path))
            {
                CharacterViewer tcharacter = CharacterUtils.LoadCharacterFromPrefab(path);
                if (tcharacter == null)
                    return;

                CharacterData data = tcharacter.GenerateCharacterData();
                this.character.AssignCharacterData(data);
                dialog.DisplayDialog("Load Character", "'" + tcharacter.name + "' is loaded");
            }
#endif
            _processing = false;
        }

        /// <summary>
        /// Save character's data as JSON file. Calling this function will save character's data with path defined in JSONRuntimePath field.
        /// </summary>
        public void SaveCharacterToJSON()
        {
            _processing = true;
            string path = "";

#if UNITY_EDITOR
            path = CharacterUtils.ShowSaveFileDialog("Save Character", "New Character Data", "json");
#else
			path = this.JSONRuntimePath;
#endif

            if (!string.IsNullOrEmpty(path))
            {
                this.character.SaveToJSON(path);
                dialog.DisplayDialog("Save Character", "'" + System.IO.Path.GetFileNameWithoutExtension(path) + "' is saved");
            }
            _processing = false;
        }

        /// <summary>
        /// Load character from JSON file's data. Calling this function will try to load character's data from a path defined in JSONRuntimePath field.
        /// </summary>
        public void LoadCharacterFromJSON()
        {
            _processing = true;
            string path = "";

#if UNITY_EDITOR
            path = CharacterUtils.ShowOpenFileDialog("Load Character", "json");
#else
			path = this.JSONRuntimePath;
#endif

            if (!string.IsNullOrEmpty(path))
            {
                this.character.LoadFromJSON(path);
                dialog.DisplayDialog("Load Character", "'" + System.IO.Path.GetFileNameWithoutExtension(path) + "' is loaded");
            }
            _processing = false;
        }

        /// <summary>
        /// Randomize character's body
        /// </summary>
        public void RandomizeBody()
        {
            character.SetBodyType(RollDice() > 50 ? BodyType.Male : BodyType.Female);
        }

        /// <summary>
        /// Randomize character's skin color
        /// </summary>
        public void RandomizeSkinColor()
        {
            List<Color> skins = GetColors("Skin");
            character.SkinColor = skins[Random.Range(0, skins.Count)];
        }

        /// <summary>
        /// Randomize character's body sliders
        /// </summary>
        public void RandomizeBodySliders()
        {
            BodySegmentSlider[] sliders = this.transform.GetComponentsInChildren<BodySegmentSlider>(true);
            foreach (BodySegmentSlider s in sliders)
                s.RandomizeScale();
        }

        /// <summary>
        /// Randomize character's parts.
        /// </summary>
        public void RandomizePart()
        {
            RandomizePart(new SlotCategory[0]);
        }
        
        /// <summary>
        /// Randomize character's parts
        /// </summary>
        /// <param name="excludedCategory">(optional)Excluded SlotCategory</param>
        public void RandomizePart(params SlotCategory[] excludedCategory)
        {
            List<SlotCategory> excludedcats = new List<SlotCategory>(excludedCategory);
            // Get all available parts if null
            if (_availparts == null || _availparts.Count <= 0)
            {
                _availparts = new Dictionary<SlotCategory, List<Part>>();
                foreach (SlotCategory c in System.Enum.GetValues(typeof(SlotCategory)))
                    _availparts.Add(c, PartList.Static.FindParts(c));
            }

            // Equip
            foreach (SlotCategory c in System.Enum.GetValues(typeof(SlotCategory)))
            {
                if (excludedcats.Contains(c))
                    continue;
                switch (c)
                {
                    case SlotCategory.OffHand:
                        Weapon w = character.GetAssignedPart(SlotCategory.MainHand) as Weapon;
                        if (w == null)
                            character.EquipPart(c, nullpart);
                        else if (w.weaponCategory != WeaponCategory.TwoHanded && RollDice() < _RANDSETTINGS[c])
                            character.EquipPart(c, _availparts[c][Random.Range(0, _availparts[c].Count)]);
                        break;
                    case SlotCategory.Ear:
                        if (RollDice() < _RANDSETTINGS[c])
                            character.EquipPart(c, _availparts[c][Random.Range(0, _availparts[c].Count)]);
                        else
                            character.EquipPart(c, "00", "Base");
                        break;
                    case SlotCategory.Pants:
                        int ppants = character.GetAssignedPart(SlotCategory.Skirt) != null ? 50 : 100;
                        if (RollDice() < ppants)
                            character.EquipPart(c, _availparts[c][Random.Range(0, _availparts[c].Count)]);
                        else
                            character.EquipPart(c, "00", "Base");
                        break;
                    case SlotCategory.Skirt:
                        int pskirt = character.bodyType == BodyType.Female ? 40 : 20;
                        if (RollDice() < pskirt)
                        {
                            character.EquipPart(c, _availparts[c][Random.Range(0, _availparts[c].Count)]);
                            character.EquipPart(SlotCategory.Pants, RollDice() < 50 ? _availparts[SlotCategory.Pants][Random.Range(0, _availparts[SlotCategory.Pants].Count)] : nullpart);
                        }
                        else
                        {
                            character.EquipPart(c, nullpart);
                            character.EquipPart(SlotCategory.Pants, _availparts[SlotCategory.Pants][Random.Range(0, _availparts[SlotCategory.Pants].Count)]);
                        }
                        break;
                    default:
                        character.EquipPart(c, RollDice() < _RANDSETTINGS[c] ? _availparts[c][Random.Range(0, _availparts[c].Count)] : nullpart);
                        break;
                }
            }
        }

        /// <summary>
        /// Randomize desired color(s) of character's part(s)
        /// </summary>
        public void RandomizeColor()
        {
            this.RandomizeColor(new SlotCategory[0]);
        }

        /// <summary>
        /// Randomize desired color(s) of character's part(s)
        /// </summary>
        /// <param name="excludedCategory">(optional) Excluded SlotCategory</param>
        public void RandomizeColor(params SlotCategory[] excludedCategory)
        {
            List<SlotCategory> excludedcats = new List<SlotCategory>(excludedCategory);
            // Roll flashiness & variant
            int flashiness = RollDice();
            int variant = RollDice();
            List<Color> colorpool = new List<Color>();
            List<Color> colortheme = new List<Color>();
            List<Color> haircolor = GetColors("Hair");
            List<Color> lipscolor = GetColors("Lips");
            List<Color> tattcolor = GetColors("Grayscale");
            List<Color> eyecolor = GetColors("Eyes");
            colorpool.AddRange(GetColors("Bleak"));
            colorpool.AddRange(GetColors("Dark"));
            colorpool.AddRange(GetColors("Leather"));
            colorpool.AddRange(GetColors("Grayscale"));
            lipscolor.AddRange(GetColors("Skin"));
            tattcolor.AddRange(GetColors("Bleak"));
            tattcolor.AddRange(GetColors("Fabric"));
            tattcolor.AddRange(GetColors("Vibrant"));
            if (flashiness >= 20) // Bleak and dark
            {
                colorpool.AddRange(GetColors("Metal"));
                colorpool.AddRange(GetColors("Bleached"));
                haircolor.AddRange(GetColors("Metal"));
                haircolor.AddRange(GetColors("Eyes"));
                lipscolor.AddRange(GetColors("Bleached"));
            }
            if (flashiness >= 50) // Somewhat normal
            {
                colorpool.AddRange(GetColors("Fabric"));
                haircolor.AddRange(GetColors("Fabric"));
                haircolor.AddRange(GetColors("Vibrant"));
                lipscolor.AddRange(GetColors("Fabric"));
                lipscolor.AddRange(GetColors("Bleak"));
                lipscolor.AddRange(GetColors("Dark"));
            }
            if (flashiness >= 80) // Flashy af
            {
                colorpool.AddRange(GetColors("Vibrant"));
                haircolor.AddRange(GetColors("Bleached"));
                lipscolor.AddRange(GetColors("Vibrant"));
            }
            if (variant <= 30)
                for (int i = 0; i < 6; i++)
                    colortheme.Add(colorpool[Random.Range(0, colorpool.Count)]);
            else if (variant > 30 && variant < 80)
                for (int i = 0; i < 9; i++)
                    colortheme.Add(colorpool[Random.Range(0, colorpool.Count)]);
            else if (variant >= 80)
                for (int i = 0; i < 12; i++)
                    colortheme.Add(colorpool[Random.Range(0, colorpool.Count)]);
            if (RollDice() > 60)
                eyecolor.AddRange(GetColors("Vibrant"));
            // Set equipment colors
            if (!excludedcats.Contains(SlotCategory.Armor))
                character.SetPartColor(SlotCategory.Armor, colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)]);
            if (!excludedcats.Contains(SlotCategory.Pants))
                character.SetPartColor(SlotCategory.Pants, colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)]);
            if (!excludedcats.Contains(SlotCategory.Helmet))
                character.SetPartColor(SlotCategory.Helmet, colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)]);
            if (!excludedcats.Contains(SlotCategory.Gloves))
                character.SetPartColor(SlotCategory.Gloves, colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)]);
            if (!excludedcats.Contains(SlotCategory.Boots))
                character.SetPartColor(SlotCategory.Boots, colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)]);
            if (!excludedcats.Contains(SlotCategory.Cape))
                character.SetPartColor(SlotCategory.Cape, colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)]);
            if (!excludedcats.Contains(SlotCategory.MainHand))
                character.SetPartColor(SlotCategory.MainHand, colorpool[Random.Range(0, colorpool.Count)], colorpool[Random.Range(0, colorpool.Count)], colorpool[Random.Range(0, colorpool.Count)]);
            if (!excludedcats.Contains(SlotCategory.OffHand))
                character.SetPartColor(SlotCategory.OffHand, colorpool[Random.Range(0, colorpool.Count)], colorpool[Random.Range(0, colorpool.Count)], colorpool[Random.Range(0, colorpool.Count)]);
            if (!excludedcats.Contains(SlotCategory.Skirt))
                character.SetPartColor(SlotCategory.Skirt, colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)], colortheme[Random.Range(0, colortheme.Count)]);
            // Set face colors
            Color newcolor = haircolor[Random.Range(0, haircolor.Count)];
            if (!excludedcats.Contains(SlotCategory.Hair))
                character.SetPartColor(SlotCategory.Hair, ColorCode.Color1, newcolor);
            if (!excludedcats.Contains(SlotCategory.FacialHair))
                character.SetPartColor(SlotCategory.FacialHair, ColorCode.Color1, newcolor);
            if (!excludedcats.Contains(SlotCategory.Eyebrow))
            {
                if (flashiness < 80)
                    character.SetPartColor(SlotCategory.Eyebrow, ColorCode.Color1, newcolor);
                else
                    character.SetPartColor(SlotCategory.Eyebrow, ColorCode.Color1, haircolor[Random.Range(0, haircolor.Count)]);
            }
            if (!excludedcats.Contains(SlotCategory.Eyes))
                character.SetPartColor(SlotCategory.Eyes, ColorCode.Color1, eyecolor[Random.Range(0, eyecolor.Count)]);
            if (!excludedcats.Contains(SlotCategory.Mouth))
            {
                if (character.bodyType == BodyType.Female)
                    character.SetPartColor(SlotCategory.Mouth, ColorCode.Color1, lipscolor[Random.Range(0, lipscolor.Count)]);
                else
                    character.SetPartColor(SlotCategory.Mouth, ColorCode.Color1, character.SkinColor);
            }
            if (!excludedcats.Contains(SlotCategory.SkinDetails))
            {
                if (character.GetAssignedPart(SlotCategory.SkinDetails) != null)
                {
                    newcolor = tattcolor[Random.Range(0, tattcolor.Count)];
                    if (RollDice() > 50) newcolor.a = Random.Range(0.2f, 1f);
                }
                else newcolor = Color.gray;
                character.SetPartColor(SlotCategory.SkinDetails, ColorCode.Color1, newcolor);
            }
        }

        int RollDice ()
        {
            int i = Random.Range(0,100);
            return i;
        }

        List<Color> GetColors (string palette)
        {
            List<Color> colors = new List<Color>();
            foreach (ColorPalette p in this.colorUI.colorPalette.colorPalettes)
            {
                if (p.paletteName == palette)
                {
                    foreach (Color c in p.colors) colors.Add(c);
                    break;
                }
            }
            return colors;
        }
    }
}