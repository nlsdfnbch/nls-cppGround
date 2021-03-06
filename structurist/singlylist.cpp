
#include <iostream>
#include<cstdlib>
using namespace std;


struct ListItem {
    unsigned int data;
    struct ListItem *next;
};

ListItem* push_sl(int value, ListItem **head)
{
    ListItem *newEntry; // register a name with your machine for a var
    newEntry = (ListItem*)malloc(sizeof(struct ListItem)); // reserve memory for an object with the size of a listItem
    newEntry->data = value;
    newEntry->next = *head;
    *head = newEntry;
    return 0;
}

void push_tail_sl(int value, ListItem **head)
{
    if (*head == NULL){
            push_sl(value, head);
            return;
        }
    for (ListItem *i = *head; i!=0; i = i->next){

        if (i->next == NULL){

            ListItem *newEntry; // register a name with your machine for a var
            newEntry = (ListItem*)malloc(sizeof(struct ListItem)); // reserve memory for an object with the size of a listItem
            newEntry->data = value;
            newEntry->next = NULL;
            i->next = newEntry;
            return;

        };
    };
}

ListItem* pop_sl(ListItem **head)
{
    ListItem* neck = (*head)->next;
    free(*head);
    *head = neck;
    return neck;
}

void pop_tail_sl(ListItem **head)
{
    if (*head == NULL)
    {
        pop_sl(head);
        return;
    };

    for (ListItem *i = *head; i!=0; i = i->next)
    {
        if (i->next->next == NULL){
            ListItem* A = i->next;
            i->next = i->next->next;
            free(A);
            return;
        };
    };

}

int hasloop(ListItem **head){
    int pos = 0;

    if ((*head)->next == NULL){
        return -1;
    }

    ListItem* nodeA = *head;
    ListItem* nodeB = (*head)->next;

    while(nodeB != NULL){
        pos++;

        nodeA = nodeA->next;

        if (nodeB->next == NULL){
            return -1;
        }
        nodeB = nodeB->next->next;

        if(nodeA == nodeB){
            return pos;
        }
    }
    return false;
}

ListItem* printLoopStart(ListItem **head,int loopStart){
    ListItem* A = *head;
    ListItem* B = *head;
    for(int i = 0; i <= loopStart; i++){
        if(i == loopStart){
            return *head;
        }

    }



}

#if 0
int main()
{

    ListItem* head = NULL;


    for (int i = 0; i < 10; i++){

        push_sl(i, &head);

    };

    for (int i = 0; i<100000; i++){
        for(int a = 0; a<50; a++){
            push_sl(a, &head);
        };
        for(int a = 0; a<25; a++){
            pop_sl(&head);
        };
        for(int a = 0; a<50; a++){
            push_sl(a, &head);
        };
        for(int a = 0; a<75; a++){
            pop_sl(&head);
        };
    };

}
#endif

