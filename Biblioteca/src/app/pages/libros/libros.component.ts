import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { AutoresService } from 'src/app/services/autores.service';
import { LibrosService } from 'src/app/services/libros.service';
import * as fs from 'file-saver';
import { Workbook } from 'exceljs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalChargeComponent } from 'src/app/modal/modal-charge/modal-charge.component';

@Component({
  selector: 'app-libros',
  templateUrl: './libros.component.html',
  styleUrls: ['./libros.component.scss']
})
export class LibrosComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  libros: any;
  autores:any;
  dtTrigger: Subject<any> = new Subject<any>();
  autorSeleccionado:any;
  verSeleccionAutor:any;
  fechaInicio:any;
  fechaFin:any;
  
  constructor(private librosServices:LibrosService,
              private autoresServices:AutoresService,
              private modalService: NgbModal) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      language:{
        url:'//cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json'
      },
    };
  
    this.autoresServices.getAllAutores().subscribe(data=>{
      this.autores=data;
      console.log("Data Autores",data )
    });

    this.librosServices.getAllLibros().subscribe(data => {
        
        this.libros = data;
        console.log('Libros',data);
        // Calling the DT trigger to manually render the table
        this.dtTrigger.next();
      });
      this.modalService.open( ModalChargeComponent,{size:'lg'})
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  capturar() {
    this.verSeleccionAutor = this.autorSeleccionado;
    console.log(this.verSeleccionAutor);

    this.librosServices.getLibrosByIdAutor(this.verSeleccionAutor).subscribe(data => {
      this.libros = data;
      console.log('Libros',data);
      // Calling the DT trigger to manually render the table
    });
  }

  submit(){
    console.log(this.fechaInicio);
    console.log(this.fechaFin);

    let fechaInicioEntry=this.fechaInicio.year+'-'+this.fechaInicio.month+'-'+this.fechaInicio.day
    let fechaFinEntry=this.fechaFin.year+'-'+this.fechaFin.month+'-'+this.fechaFin.day
    this.librosServices.getLibrosByRangeDate(fechaInicioEntry,fechaFinEntry).subscribe(data => {
      this.libros = data;
      console.log('Libros',data);
      // Calling the DT trigger to manually render the table
    });
  }


  downloadExcel(){
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet("Employee Data");
    let header=["ID","Nombre Libro","No Paginas","Fecha Publicacion",]
    let headerRow = worksheet.addRow(header);
      for (let x1 of this.libros)
          {
            let x2=Object.keys(x1);
            let temp=[]
            for(let y of x2)
            {
              temp.push(x1[y])
            }
            worksheet.addRow(temp)
          }

    let fname="Biblioteca Datos"

    //add data and file name and download
    workbook.xlsx.writeBuffer().then((data) => {
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fs.saveAs(blob, fname+'-'+new Date().valueOf()+'.xlsx');
    });  
    
  }
}
