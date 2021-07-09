import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AutoresService } from 'src/app/services/autores.service';
import { LibrosService } from 'src/app/services/libros.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ModalChargeComponent } from 'src/app/modal/modal-charge/modal-charge.component';
@Component({
  selector: 'app-biblioteca-home',
  templateUrl: './biblioteca-home.component.html',
  styleUrls: ['./biblioteca-home.component.scss']
})
export class BibliotecaHomeComponent implements OnInit {

  constructor( private autoresServices:AutoresService,
               private librosServices:LibrosService,
               private modalService: NgbModal) { }

  ngOnInit(): void {
    this.autoresServices.getAllAutores().subscribe(res=>{
      res;
      console.log("Data Autores",res )
    });

    this.librosServices.getAllLibros().subscribe(res=>{
      res;
      console.log("Data Libros",res )
    });

    this.open();
  }

  cerrar(){
    this.modalService.dismissAll();
  }

  open(){
    this.modalService.open( ModalChargeComponent,{size:'lg'})
  }

}
