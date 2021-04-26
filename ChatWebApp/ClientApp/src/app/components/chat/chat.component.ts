import { Component, OnInit, ViewChild} from '@angular/core';
import { ChatService } from 'src/app/services/chat.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  mebrersList: any[] = [];
  messageList: any[] = [];
  personName: String;
  messageText: String;

  constructor(private chatService: ChatService, private route: ActivatedRoute, private router: Router) { 
    this.route.paramMap.subscribe(params => {
      try{
        let name = params.get('name');
        if(name && name !=''){
          this.personName = name;
          
          chatService.getAllMessages().subscribe( (messages: any[]) => {
            this.messageList = messages.map(item => {
              item["owner"] = item.ownerName === this.personName? true: false;
              return item;
            });
          });

          this.chatService.chatWebSocket.subscribe(
            data => this.reciveMsg(data),
            err => console.warn(err),
            () => console.log('complete')
          );
        }else{
          this.router.navigateByUrl('/');
        }
      }catch( e ){
        this.router.navigateByUrl('/');
      }
    });
    
  }

  ngAfterViewChecked() {        
    this.scrollToBottom();        
  } 

  scrollToBottom(): void {
      try {
          
        } catch(err) { 
          console.log(err);
        }                 
  }

  reciveMsg(data: string){
    try{
      let msg = JSON.parse(data);
      msg["owner"] = msg.ownerName === this.personName? true: false;
      this.messageList.push(msg);
      //this.scrollToBottom();
    }catch(e){
      console.warn(e);
    }
    
  }

  ngOnInit() {}

  sendMsg(){
    if(this.messageText && this.messageText !== ""){
      this.chatService.sendMessage({
        name: this.personName,
        message: this.messageText
      });
      this.messageText = "";
    }
  }

}
