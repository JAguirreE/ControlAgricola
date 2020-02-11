<template>
  <section id="facturacion">
    <mdb-row>
      <mdb-col md="12">
        <mdb-card cascade narrow class="mt-5">
          <mdb-view class="gradient-card-header blue darken-2">
            <h4 class="h4-responsive text-white">Facturación</h4>
          </mdb-view>

          <mdb-card-body>
            <h3 class="mt-5 text-left">
              <strong>Facturas Encontradas</strong>
            </h3>
            <p></p>
            <router-link to="/facturacionDetalle">
              <button class="btn btn-primary">Nueva Factura</button>
            </router-link>
            <mdb-tbl>
              <thead class="mdb-color darken-3">
                <tr class="text-white">
                  <th>#</th>
                  <th>Emisor</th>
                  <th>Receptor</th>
                  <th>Valor total</th>
                  <th>Fecha</th>
                  <th></th>
                </tr>
              </thead>
              <tbody></tbody>
              <tr v-for="factura in facturas" :key="factura.idFac">
                <td>
                  <router-link
                    :to="{
                      name: 'FacturacionDetalle',
                      params: { idFac: factura.idFac }
                    }"
                    ><button type="button" class="btn btn-primary">
                      {{ factura.numero }}
                    </button></router-link
                  >
                </td>
                <td>{{ factura.emisor }}</td>
                <td>{{ factura.receptor }}</td>
                <td>{{ factura.valorTotal }}</td>
                <td>{{ factura.fecha }}</td>
                <td>
                  <button
                    type="button"
                    class="btn btn-danger"
                    @click="deleteFactura(factura.idFac)"
                  >
                    Eliminar
                  </button>
                </td>
              </tr>
            </mdb-tbl>
          </mdb-card-body>
        </mdb-card>
      </mdb-col>
    </mdb-row>
  </section>
</template>

<script>
import {
  mdbRow,
  mdbCol,
  mdbCard,
  mdbView,
  mdbCardBody,
  mdbTbl,
  mdbBtn
} from "mdbvue";

import { Services, Notifications } from "../../index";
export default {
  name: "Facturacion",
  components: {
    mdbRow,
    mdbCol,
    mdbCard,
    mdbView,
    mdbCardBody,
    mdbTbl,
    mdbBtn
  },
  data() {
    return {
      facturas: []
    };
  },
  methods: {
    getFacturas() {
      Services.get("General/GetFacturas")
        .then(res => {
          this.facturas = res;
        })
        .catch(err => {
          Notifications.error(err);
        });
    },
    deleteFactura(idFac) {
      Services.post("General/DeleteFacturaAll", { idFac: idFac })
        .then(res => {
          console.log(res);
          this.getFacturas();
        })
        .catch(err => {
          Notifications.error(err);
        });
    }
  },
  mounted() {
    this.getFacturas();
  }
};
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.card.card-cascade .view.gradient-card-header {
  padding: 1rem 1rem;
  text-align: center;
}
.card.card-cascade h3,
.card.card-cascade h4 {
  margin-bottom: 0;
}
</style>
