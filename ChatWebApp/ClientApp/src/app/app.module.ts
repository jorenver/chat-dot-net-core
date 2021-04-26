import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { JoinRoomComponent } from './components/join-room/join-room.component';
import { ChatComponent } from './components/chat/chat.component';
import { MenberChatComponent } from './components/menber-chat/menber-chat.component';
import { MessageChatComponent } from './components/message-chat/message-chat.component';
import { MessageUserNamePipe } from './pipes/message-user-name.pipe';
import { ChatService } from './services/chat.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    JoinRoomComponent,
    ChatComponent,
    MenberChatComponent,
    MessageChatComponent,
    MessageUserNamePipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: JoinRoomComponent, pathMatch: 'full' },
      { path: 'join-room', component: JoinRoomComponent },
      { path: 'chat-room/:name', component: ChatComponent },
      { path: '**', redirectTo: '' }
    ])
  ],
  providers: [ChatService],
  bootstrap: [AppComponent]
})
export class AppModule { }
