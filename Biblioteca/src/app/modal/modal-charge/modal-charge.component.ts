import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-charge',
  templateUrl: './modal-charge.component.html',
  styleUrls: ['./modal-charge.component.scss']
})
export class ModalChargeComponent implements OnInit {

  barraCarga=0;
  id:any;
  constructor(public modal:NgbModal) { }

  ngOnInit(): void {
    this.contador();
  }

  contador(){
    this.id=setInterval(() => {
      this.barraCarga+=5;
      if(this.barraCarga==100)
      {
        clearInterval(this.id);
      }
      
    }, 150);

    
  }
  cerrar(){
    this.modal.dismissAll();
  }

}
