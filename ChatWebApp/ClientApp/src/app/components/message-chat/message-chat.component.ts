import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-message-chat',
  templateUrl: './message-chat.component.html',
  styleUrls: ['./message-chat.component.css']
})
export class MessageChatComponent implements OnInit {
  
  @Input() message: any = {};
  constructor() { }

  ngOnInit() {
  }

}
