using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

namespace ExtraTools
{

    public class Message
    {
        public Sprite img;
        public string message;

        public MessageButton[] buttons;

        public Message() { }
        public Message(in string _message, in Sprite _img, params MessageButton[] _buttons)
        {
            img = _img;
            message = _message;
            buttons = _buttons;
        }
    }

    public class MessageButton
    {
        public string buttonText;
        public UnityAction buttonAction;

        public MessageButton(string _buttonText, UnityAction _buttonAction)
        {
            buttonText = _buttonText;
            buttonAction = _buttonAction;
        }
    }

    public class PopUp : Singleton<PopUp>
    {
        [SerializeField]
        private TextMeshProUGUI messageLabel;
        [SerializeField]
        private Image messageImage;
        [SerializeField]
        private TextMeshProUGUI message;
        [SerializeField]
        private GameObject buttonPrefab;
        [SerializeField]
        private Transform buttonsContent;
        [SerializeField]
        private GameObject windowPanel;

        private List<Button> buttons = new List<Button>();

        private Queue<Message> messages = new Queue<Message>();

        private float checkTimer = 1;

        /// <summary>
        /// Creates and adds a message to the queue
        /// </summary>
        /// <param name="msg">The text of the message</param>
        /// <param name="img">A sprite to show alongside the question</param>
        public void Register(in string msg, in Sprite img = null, params MessageButton[] buttons)
        {
            Register(new Message(msg, img, buttons));
        }

        /// <summary>
        /// Adds a message to the queue
        /// </summary>
        /// <param name="msg"></param>
        public void Register(Message msg)
        {
            messages.Enqueue(msg);
            if (!windowPanel.activeSelf)
            {
                windowPanel.SetActive(true);
                CheckMessages();
            }
        }

        /// <summary>
        /// Sets the message to the PopUp window
        /// </summary>
        /// <param name="msg"></param>
        private void SetMessage(Message msg)
        {
            //Set image if needed. Disable the image object otherwise
            if (msg.img)
            {
                messageImage.gameObject.SetActive(true);
                messageImage.sprite = msg.img;
            }
            else
            {
                messageImage.gameObject.SetActive(false);
            }

            //Set the message text
            message.text = msg.message;

            //Set buttons
            if (msg.buttons == null || msg.buttons.Length == 0)
            {
                Button btn = GetButton();
                btn.GetComponentInChildren<TextMeshProUGUI>().text = "OK";
                btn.onClick.AddListener(ClearButtons);
                btn.onClick.AddListener(CheckMessages);
                btn.Select();
                StartCoroutine(SelectContinueButtonLater(btn.gameObject));
            }
            else
            {
                Button temp = null;
                Button selectThis = null;
                foreach (MessageButton btn in msg.buttons)
                {
                    temp = GetButton();
                    if (selectThis == null)
                        selectThis = temp;
                    if (btn.buttonAction != null)
                        temp.onClick.AddListener(btn.buttonAction);
                    temp.onClick.AddListener(ClearButtons);
                    temp.onClick.AddListener(CheckMessages);
                    temp.GetComponentInChildren<TextMeshProUGUI>().text = btn.buttonText;
                }

                selectThis.Select();
                StartCoroutine(SelectContinueButtonLater(selectThis.gameObject));
            }
        }

        private IEnumerator SelectContinueButtonLater(GameObject obj)
        {
            yield return null;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(obj);
        }

        private void Update()
        {
            if(checkTimer <= 0 && !EventSystem.current.currentSelectedGameObject && buttons.Count > 0)
            {
                checkTimer = 1;
                buttons[0].Select();
                StartCoroutine(SelectContinueButtonLater(buttons[0].gameObject));
            }
            checkTimer -= Time.deltaTime;
        }

        /// <summary>
        /// Disabled all buttons and remove all listeners from each button
        /// </summary>
        private void ClearButtons()
        {
            foreach (Button btn in buttons)
            {
                btn.onClick.RemoveAllListeners();
                btn.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Checks the buttons in the pool and returns the first disabled one
        /// Instantiates a new one if no buttons are availeble in the pool
        /// </summary>
        /// <returns></returns>
        private Button GetButton()
        {
            foreach (Button go in buttons)
            {
                if (!go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(true);
                    return go;
                }
            }

            buttons.Add(Instantiate(buttonPrefab, buttonsContent).GetComponent<Button>());
            return buttons[buttons.Count - 1];
        }

        /// <summary>
        /// Check if any messages remains in the queue
        /// </summary>
        private void CheckMessages()
        {
            if (messages.Count > 0)
            {
                //Set message label text
                SetMessage(messages.Dequeue());
                messageLabel.text = string.Format("Got {0} message{1}", (messages.Count + 1).ToString(), messages.Count == 0 ? string.Empty : "s");
            }
            else
                windowPanel.SetActive(false);
        }

        public bool IsActive()
        {
            return windowPanel.gameObject.activeSelf;
        }
    }
}
