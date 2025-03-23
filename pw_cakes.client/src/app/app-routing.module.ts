import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccueilClientComponent } from './partie_client/accueil-client/accueil-client.component';
import { VoirCatalogueComponent } from './partie_client/voir-catalogue/voir-catalogue.component';

const routes: Routes = [
  {path: '', component: AccueilClientComponent},
  {path: 'visiter-catalogue', component: VoirCatalogueComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}