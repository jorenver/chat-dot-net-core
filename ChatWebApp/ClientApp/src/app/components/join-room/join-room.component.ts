import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-join-room',
  templateUrl: './join-room.component.html',
  styleUrls: ['./join-room.component.css']
})
export class JoinRoomComponent implements OnInit {
  userName: string;

  constructor(private router: Router) { }

  ngOnInit() {
    
  }

  joinRoom(){
    if (this.userName && this.userName !== ""){
      this.router.navigateByUrl(`/chat-room/${this.userName}`);
    }else{
      alert('User Name is required!');
    }
    
  }

}
