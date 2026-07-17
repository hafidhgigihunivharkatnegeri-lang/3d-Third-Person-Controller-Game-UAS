using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GemsManager : MonoBehaviour
{
public static GemsManager instance;
public TMP_Text gemText;
public int currentGem = 0;
void Awake() {
instance =this;
}
// Start is called before the first frame update
void Start()
{
gemText.text= "Coins : " + currentGem.ToString();
}
// Update is called once per frame
public void IncreaseGems(int v)
{
currentGem += v;
gemText.text= "Coins : " + currentGem.ToString();
}
}
