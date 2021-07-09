import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { BibliotecaHomeComponent } from './pages/biblioteca-home/biblioteca-home.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { LibrosComponent } from './pages/libros/libros.component';
import { DataTablesModule } from "angular-datatables";
import { ModalChargeComponent } from './modal/modal-charge/modal-charge.component';


const routes: Routes =[
  { path:'', component: BibliotecaHomeComponent},
  { path:'libros', component: LibrosComponent},
  { path:'modalCharge', component: ModalChargeComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    BibliotecaHomeComponent,
    LibrosComponent,
    ModalChargeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    DataTablesModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
