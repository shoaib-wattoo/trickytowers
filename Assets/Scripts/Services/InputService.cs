using UnityEngine;
using System.Collections;

public class InputService : MonoBehaviour
{
    public bool isActive;
    public InputMethod inputType;

    void Awake()
    {
#if UNITY_EDITOR
        inputType = InputMethod.MouseInput;
#else
        inputType = InputMethod.TouchInput;
#endif

    }

    void Update()
    {
        if (isActive)
        {
            if (inputType == InputMethod.KeyboardInput)
                KeyboardInput();
            else if (inputType == InputMethod.MouseInput)
                MouseInput();
            else if (inputType == InputMethod.TouchInput)
                TouchInput();
        }
    }

#region KEYBOARD
    void KeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow))
            RotateClockWise(false);
        else if (Input.GetKeyDown(KeyCode.D))
            RotateClockWise(true);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveHorizontal(Vector2.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveHorizontal(Vector2.right);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Services.GameService.currentShape != null)
            {
                isActive = false;
                InstantFall();
            }
        }
    }
#endregion

#region MOUSE
    Vector2 _startPressPosition;
    Vector2 _endPressPosition;
    Vector2 _currentSwipe;
    float _buttonDownPhaseStart;
    public float tapInterval;

    void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            _startPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _buttonDownPhaseStart = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Time.time - _buttonDownPhaseStart > tapInterval)
            {
                //save ended touch 2d point
                _endPressPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //create vector from the two points
                _currentSwipe = new Vector2(_endPressPosition.x - _startPressPosition.x, _endPressPosition.y - _startPressPosition.y);

                //normalize the 2d vector
                _currentSwipe.Normalize();

                //swipe left
                if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                {
                    MoveHorizontal(Vector2.left);
                }
                //swipe right
                if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                {
                    MoveHorizontal(Vector2.right);
                }

                //swipe down
                if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                {
                    if (Services.GameService.currentShape != null)
                    {
                        isActive = false;
                        InstantFall();
                    }
                }
            }
            else
            {
                if (_startPressPosition.x < Screen.width / 2)
                    RotateClockWise(false);
                else
                    RotateClockWise(true);
            }
        }
    }
#endregion

#region TOUCH
    void TouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _startPressPosition = touch.position;
                _endPressPosition = touch.position;
                _buttonDownPhaseStart = Time.time;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                _endPressPosition = touch.position;

            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (Time.time - _buttonDownPhaseStart > tapInterval)
                {
                    //save ended touch 2d point
                    _endPressPosition = new Vector2(touch.position.x, touch.position.y);

                    //create vector from the two points
                    _currentSwipe = new Vector2(_endPressPosition.x - _startPressPosition.x, _endPressPosition.y - _startPressPosition.y);

                    //normalize the 2d vector
                    _currentSwipe.Normalize();

                    //swipe left
                    if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        MoveHorizontal(Vector2.left);
                    }
                    //swipe right
                    if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        MoveHorizontal(Vector2.right);
                    }

                    //swipe down
                    if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        if (Services.GameService.currentShape != null)
                        {
                            isActive = false;
                            InstantFall();
                        }
                    }
                }
                else /*if (_currentSwipe.x + _currentSwipe.y< 0.5f */
                {
                    if (_startPressPosition.x < Screen.width / 2)
                        RotateClockWise(false);
                    else
                        RotateClockWise(true);
                }
            }
        }

    }
#endregion

#region Direction Callbacks

    private void MoveHorizontal(Vector2 vector2)
    {
        print("MoveHorizontal : " + vector2.ToString());
        Services.GameService.currentShape.MoveHorizontal(vector2);
    }

    private void InstantFall()
    {
        print("InstantFall");
        Services.GameService.currentShape.InstantFall();
    }

    private void RotateClockWise(bool rotateClockwise)
    {
        print("RotateClockWise : " + rotateClockwise);
        Services.GameService.currentShape.RotateClockWise(rotateClockwise);
    }
    #endregion

}
