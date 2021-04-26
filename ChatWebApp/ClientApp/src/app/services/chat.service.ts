import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import {webSocket, WebSocketSubject} from 'rxjs/webSocket';

// export interface Message{
//   author: string,
//   message: string
// }

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private serviceURL: String;
  public chatWebSocket: WebSocketSubject<any> = webSocket({
    url: environment.CHAT_URL,
    deserializer: response => response.data
  });

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(`Chat Service ready ${baseUrl}`);
    this.serviceURL = baseUrl;
    console.log(`Chat WebSocket ready ${environment.CHAT_URL}`);
  }

  getQuery( query: string ) {
    const url = `${ this.serviceURL }api/${ query }`;
    console.log(url);
    return this.http.get(url);
  }


  getAllMessages(){
      return this.getQuery('message');  
  }

  sendMessage(msg){
    this.chatWebSocket.next(msg);
  }
}
