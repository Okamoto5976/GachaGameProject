using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TicketCounter : MonoBehaviour
{
    [SerializeField] private  Text ticketsText;
    private GachaSysteme tickets;
    void Start()
    {
        //UpdateTiecktsText();
    }
    public void AddTickets(int amount)
    {
        if (tickets != null)
        {
            ticketsText.text = $"Tickets:{tickets}";
        }
        else
        {
            Debug.LogWarning("Tickets Text is not assigned!");
        }
    }

   
}
