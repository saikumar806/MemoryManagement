using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    /*
     * What is memory management
     * Memory management is a process of alloacating the memory and deallocating the memory..
     * In .net memory management is handling by garbage collector.
     * Grabage collector is an integral compoennt of CLR.
     * CLR is an integral component of .net framework.
     * 
     * Manged Heap:
     * Heap is a data structure which can contain collection of objects.
     * Grabage collector is using the Heap data structure for memory management.
     * due to that reason we call it as Managed Heap.
     * 
     * To perform memory management garbage collector will do 2 duties.
     * 1)Allocating the memory.
     * 2)Deallocating the memory or releasing the memory.
     * 
     * Allocating the Memory:
     * When a new object is created by the application garbage collector 
     * will allocate memory for newly created object with in the heap data structure
     * where exactly next pointer is pointing.
     * Next object pointer will be pointing to the next adjacent empty location with in the heap.
     * Heap will be occupied by couple of objects.
     * 
     *     <---Nextobjptr
     * objC
     * objB
     * objA
     * 
     * Our Application created a raw object called objD
     * Garbage collector will allocate memory for objD with in the
     * heap data structure where exactly next object pointer is pointing and
     * next object pointer will be moving to the next adjacent empty location
     * 
     * Managed Heap
     * 
     *     <--Nextobjptr
     * objD
     * objC
     * objB
     * objA
     * In this way Garbage Collector will allocate the memory for newly created objects
     * with in the heap data structure.
     * Garbage collector allocating memory for objects with in the heap continually
     * there is chance of out of memory.
     * To overcome this garbace collector is doing the second duty called deallocating
     * memory or releasing memory.
     * 
     * 2)Deallocating Memory:
     * deallocating memory is performed by the garbage collector in two steps
     * 1)Recognizing the unused objects/unreferenced objects.
     * 2)collection process.
     * 
     * 1)Recognizing the unused objects:
     * 
     * what is unreferenced object?
     * An object which is not pointing by any refenrece varibles will be called as 
     * unreferenced or unsed object.
     * As part of deallocation garbage collector will identity the unused objects with in the 
     * headp and it will give a tag called unused object .
     * 
     *   Managed Heap
     *        <---Next pointer
     *    objD
     *    objC==>unused
     *    objB
     *    objA==>unused
     * 
     * Here we have 4 objects among 4 objA and objC are unused objects and 
     * objB and objD are used objects.
     * In this way garbage collector will recognize unused objects.
     * 
     * 
     * 
     * 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
