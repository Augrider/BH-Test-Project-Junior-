using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Event queue without parameters
/// </summary>
internal class EventQueue
{
    //TODO: Add support for multiple calls resolve. Not needed now

    public event Action OnEventRaise;

    private bool receivedEventCall = false;


    public void EnqueueEvent()
    {
        receivedEventCall = true;
    }


    public void ResolveEvents()
    {
        if (receivedEventCall)
            OnEventRaise?.Invoke();
    }
}


/// <summary>
/// Generic Event queue with parameter
/// </summary>
internal class EventQueue<T1>
{
    public event Action<T1> OnEventRaise;

    private Queue<T1> receivedEventCalls = new Queue<T1>();


    public void EnqueueEvent(T1 value, bool allowMultiple = false)
    {
        if (allowMultiple || !receivedEventCalls.Contains(value))
            receivedEventCalls.Enqueue(value);
    }


    public void ResolveEvents()
    {
        while (receivedEventCalls.Count > 0)
        {
            var eventCall = receivedEventCalls.Dequeue();
            OnEventRaise?.Invoke(eventCall);
        }
    }
}


/// <summary>
/// Generic Event queue with 2 parameters
/// </summary>
internal class EventQueue<T1, T2>
{
    public event Action<T1, T2> OnEventRaise;

    private Queue<EventData> receivedEventCalls = new Queue<EventData>();


    public void EnqueueEvent(T1 value1, T2 value2, bool allowMultiple = false)
    {
        var eventCall = new EventData() { value1 = value1, value2 = value2 };

        if (allowMultiple || !receivedEventCalls.Contains(eventCall))
            receivedEventCalls.Enqueue(eventCall);
    }


    public void ResolveEvents()
    {
        while (receivedEventCalls.Count > 0)
        {
            var eventCall = receivedEventCalls.Dequeue();
            OnEventRaise?.Invoke(eventCall.value1, eventCall.value2);
        }
    }



    private struct EventData
    {
        public T1 value1;
        public T2 value2;
    }
}


/// <summary>
/// Generic Event queue with 3 parameters
/// </summary>
internal class EventQueue<T1, T2, T3>
{
    public event Action<T1, T2, T3> OnEventRaise;

    private Queue<EventData> receivedEventCalls = new Queue<EventData>();


    public void EnqueueEvent(T1 value1, T2 value2, T3 value3, bool allowMultiple = false)
    {
        var eventCall = new EventData() { value1 = value1, value2 = value2, value3 = value3 };

        if (allowMultiple || !receivedEventCalls.Contains(eventCall))
            receivedEventCalls.Enqueue(eventCall);
    }


    public void ResolveEvents()
    {
        while (receivedEventCalls.Count > 0)
        {
            var eventCall = receivedEventCalls.Dequeue();
            OnEventRaise?.Invoke(eventCall.value1, eventCall.value2, eventCall.value3);
        }
    }



    private struct EventData
    {
        public T1 value1;
        public T2 value2;
        public T3 value3;
    }
}