using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class Censorship : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] Arrows;
    public KMSelectable Asshole;
    public TextMesh[] Textmeshes;
    public Renderer hmgjkhgfjmnmgnbh;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    string FourFiftyOne = "ItwasapleasuretoburnItwasaspecialpleasuretoseethingseatentoseethingsblackenedandchangedWiththebrassnozzleinhisfistswiththisgreatpythonspittingitsvenomouskeroseneupontheworldthebloodpoundedinhisheadandhishandswerethehandsofsomeamazingconductorplayingallthesymphoniesofblazingandburningtobringdonthetattersandcharcoalruinsofhistoryWithhissymbolichelmetnumberedfourfiftyoneonhisstolidheadandhiseyesallorangeflamewiththethoughtofwhatcamenextheflickedtheigniterandthehousejumpedupinagorgingfirethatburnedtheeveningskyredandyellowandblackHestrodeinaswarmoffirefliesHewantedaboveallliketheoldjoketoshoveamarshmallowonastickinthefurnacewhiletheflappingpigeonwingedbooksdiedontheporchandlawnofthehouseWhilethebookswentupinsparklingwhirlsandblewawayonawindturneddarkwithburningMontagGrinnedthefiercegrinofallmensingedanddrivenbackbyflameHeknewthatwhenhereturnedtothefirehousehemightwinkathimselfaminstrelmanburntcorkedinthemirrorLatergoingtosleephewouldfeelthefierysmilestillgrippedbyhisfacemusclesinthedarkItneverwentawaythatsmileitnevereverwentawayaslongasherememberedHehunguphisblackbeetlecoloredhelmetandshinedithehunghisflameproofjacketneatlyheshoweredluxuriouslyandthenwhistlinghandsinpocketswalkedacrosstheupperfloorofthefirestationandfelldowntheholeAtthelastmomentwhendisasterseemedpositivehepulledhishandsfromhispocketsandbrokehisfallbygraspingthegoldenpollHeslidtoasqueakinghalttheheelsoneinchfromtheconcretefloordownstairs#";
    string FuckYouCSharp = "";
    char[] Alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    char[] HeheAlphabetGoBrrrr = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    string SelectLetter = "";
    int WeedWeedChungus = 0;
    int Asswipe = 0;
    int Index = 0;
    //int CardiacArrest = 0;
    float Hue = 0.1f;
    float Saturation = 0f;
    float Value = 1f;

    void Awake () {
        moduleId = moduleIdCounter++;
        foreach (KMSelectable Arrow in Arrows) {
            Arrow.OnInteract += delegate () { ArrowPress(Arrow); return false; };
        }

        Asshole.OnInteract += delegate () { AssholePress(); return false; };

    }

    void Start () {
      Index = UnityEngine.Random.Range(0,26);
      Textmeshes[0].text = Alphabet[Index].ToString();
      FourFiftyOne = FourFiftyOne.ToUpper();
      WeedWeedChungus = UnityEngine.Random.Range(0, FourFiftyOne.Length - 1);
      SelectLetter = FourFiftyOne[WeedWeedChungus].ToString();
      Debug.LogFormat("[Censorship #{0}] The starting letter is the {1}(th) one. That is a(n) {2}", moduleId, WeedWeedChungus, SelectLetter);
      //CardiacArrest = UnityEngine.Random.Range(1, 26); Caesar shift if i want
      HeheAlphabetGoBrrrr.Shuffle();
      for (int i = 0; i < FourFiftyOne.Length - 1; i++) {
        for (int j = 0; j < Alphabet.Length; j++) {
          if (FourFiftyOne[i] == Alphabet[j]) {
            FuckYouCSharp += HeheAlphabetGoBrrrr[j];
          }
        }
      }
      FuckYouCSharp += "#";
      StartCoroutine(WatchMeCrankItWatchMeRoll());
    }

    IEnumerator WatchMeCrankItWatchMeRoll () {
      while (true) {
        Textmeshes[1].text = FuckYouCSharp[WeedWeedChungus].ToString();
        WeedWeedChungus++;
        WeedWeedChungus %= FourFiftyOne.Length - 1;
        Asswipe++;
        Textmeshes[2].text = Asswipe.ToString();
        yield return new WaitForSeconds(1f);
      }
    }

    void ArrowPress (KMSelectable Arrow) {
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Arrow.transform);
      if (moduleSolved) {
        return;
      }
      if (Arrow == Arrows[0]) {
        Index--;
        if (Index < 0) {
          Index += 26;
        }
        Textmeshes[0].text = Alphabet[Index].ToString();
      }
      else {
        Index++;
        if (Index > 25) {
          Index -= 26;
        }
        Textmeshes[0].text = Alphabet[Index].ToString();
      }
    }

    void AssholePress () {
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Asshole.transform);
      if (moduleSolved) {
        return;
      }
      if (Textmeshes[0].text == SelectLetter) {
        GetComponent<KMBombModule>().HandlePass();
        StopAllCoroutines();
        Audio.PlaySoundAtTransform("NoHouseL", transform);
        StartCoroutine(SolveAnim());
        moduleSolved = true;
      }
      else {
        GetComponent<KMBombModule>().HandleStrike();
      }
    }
    IEnumerator SolveAnim () {
      for (int i = 0; i < 256; i++) {
        Saturation += 0.00390625f;
        if (i > 192) {
          Value -= 0.015625f;
        }
        hmgjkhgfjmnmgnbh.material.color = Color.HSVToRGB(Hue, Saturation, Value);
        yield return new WaitForSeconds(0.008f); //make this slower so it's more subtle
        }
      }

    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} X submit a specific letter.";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand (string Command) {
      Command = Command.ToUpper().Trim();
      int AssHoleCheck = 0;
      for (int i = 0; i < Alphabet.Length; i++) {
        yield return null;
        if (Alphabet[i].ToString() != Command.ToUpper()) {
          AssHoleCheck += 1;
        }
      }
      if (AssHoleCheck == 25) {
        while (Textmeshes[0].text != Command) {
          yield return null;
          Arrows[1].OnInteract();
          yield return new WaitForSeconds(0.1f);
        }
        Asshole.OnInteract();
      }
      else {
        yield return "sendtochaterror I don't understand!";
      }
    }
}
