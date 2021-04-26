import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-menber-chat',
  templateUrl: './menber-chat.component.html',
  styleUrls: ['./menber-chat.component.css']
})
export class MenberChatComponent implements OnInit {
  @Input() person: any = {};

  constructor() { }

  ngOnInit() {
  }

}
