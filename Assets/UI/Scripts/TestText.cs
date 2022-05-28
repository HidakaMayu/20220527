//using system.collections;
//using system.collections.generic;
//using unityengine;
//using unityengine.ui;

//public class testtext : monobehaviour
//{
//    [serializefield]
//    text _text = default;

//    float _timer = default;

//    bool _isstop = default;

//    void update()
//    {
//        if (_isstop) { return; }

//        _timer += time.deltatime;
//        //_text.text = $"time : {_timer.tostring("f2")}";
//        _text.text = _timer.tostring("f1");
//    }

//    public void controltime()
//    {
//        _isstop ^= true;
//    }
//}
