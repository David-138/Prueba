using UnityEngine;
using UnityEngine.UI;
public class MovimientoBola2D : MonoBehaviour
{
    public float fuerzaMovimiento = 5f;
    float barracorrer = 1f;
    public bool correr;
    public enum TipoControl
    {
        WASD,
        Flechas
    }

    [Header("Tipo de control")]
    public TipoControl tipoControl = TipoControl.WASD;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        correr = false;
    }

    void FixedUpdate()
    {
        float inputHorizontal = 0f;
        float inputVertical = 0f;
        // Selección del tipo de control
        if (tipoControl == TipoControl.WASD)
        {
            inputHorizontal = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
            inputVertical = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
            if (Input.GetKey(KeyCode.RightControl))
            {
                inputHorizontal = (Input.GetKey(KeyCode.D) ? -1 : 0) + (Input.GetKey(KeyCode.A) ? 1 : 0);
                inputVertical = (Input.GetKey(KeyCode.S) ? 1 : 0) + (Input.GetKey(KeyCode.W) ? -1 : 0);

            }
        }
        else if (tipoControl == TipoControl.Flechas)
        {
            inputHorizontal = (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0) + (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
            inputVertical = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) + (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);
            if (Input.GetKey(KeyCode.LeftControl))
            {
                inputHorizontal = (Input.GetKey(KeyCode.RightArrow) ? -1 : 0) + (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
                inputVertical = (Input.GetKey(KeyCode.DownArrow) ? 1 : 0) + (Input.GetKey(KeyCode.UpArrow) ? -1 : 0);
            }
        }

        Vector2 direccionMovimiento = new Vector2(inputHorizontal, inputVertical);

        rb.AddForce(direccionMovimiento * fuerzaMovimiento);
    }
}
