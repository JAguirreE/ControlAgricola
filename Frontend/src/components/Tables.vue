<template>
  <section id="tables">
    <mdb-row>
      <mdb-col md="12">
        <mdb-card cascade narrow class="mt-5">
          <mdb-view class="gradient-card-header blue darken-2">
            <h4 class="h4-responsive text-white">Reporte General</h4>
          </mdb-view>
          <mdb-card-body>
            <h3 class="mt-5 text-left"><strong>Fincas Registradas</strong></h3>
            <p></p>
            <mdb-tbl>
              <thead class="mdb-color darken-3">
                <tr class="text-white">
                  <th>#</th>
                  <th>Nombre</th>
                  <th>Dirección</th>
                  <th>Tamaño</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="finca in fincas" :key="finca.idFinca">
                  <td>{{ finca.idFinca }}</td>
                  <td>{{ finca.nombre }}</td>
                  <td>{{ finca.direccion }}</td>
                  <td>{{ finca.tamano }}</td>
                </tr>
              </tbody>
            </mdb-tbl>

            <h3 class="mt-5 text-left"><strong>Lotes Registrados</strong></h3>
            <p></p>
            <mdb-tbl>
              <thead class="mdb-color darken-3">
                <tr class="text-white">
                  <th>#</th>
                  <th>Nombre</th>
                  <th>Tamaño</th>
                  <th>Finca</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="lote in lotes" :key="lote.idLote">
                  <td>{{ lote.idLote }}</td>
                  <td>{{ lote.nombre }}</td>
                  <td>{{ lote.tamano }}</td>
                  <td>{{ lote.finca }}</td>
                </tr>
              </tbody>
            </mdb-tbl>

            <h3 class="mt-5 text-left">
              <strong>Actividades Registradas</strong>
            </h3>
            <p></p>
            <mdb-tbl>
              <thead class="mdb-color darken-3">
                <tr class="text-white">
                  <th>#</th>
                  <th>Tipo Actividad</th>
                  <th>Producto</th>
                  <th>Cantidad</th>
                  <th>Método</th>
                  <th>Meteorología</th>
                  <th>Agricultor</th>
                  <th>Lote</th>
                  <th>Finca</th>
                  <th>Fecha</th>
                  <th>QR</th>
                </tr>
              </thead>
              <tbody>
                <tr
                  v-for="actividad in actividades"
                  :key="actividad.idActividad"
                >
                  <td>{{ actividad.idActividad }}</td>
                  <td>{{ actividad.nombreTipoActividad }}</td>
                  <td>{{ actividad.nombreProducto }}</td>
                  <td>{{ actividad.cantidad }}</td>
                  <td>{{ actividad.metodoAplicacion }}</td>
                  <td>{{ actividad.meteorologia }}</td>
                  <td>{{ actividad.nombreUsuario }}</td>
                  <td>{{ actividad.nombreLote }}</td>
                  <td>{{ actividad.nombreFinca }}</td>
                  <td>{{ actividad.fecha }}</td>
                  <td>
                    <mdb-btn
                       v-if="actividad.idTipoActividad == 5"
                      color="primary"
                      @click="verQR(actividad.idLote)"
                      >Ver</mdb-btn
                    >
                  </td>
                </tr>
              </tbody>
            </mdb-tbl>
          </mdb-card-body>

          <div>
            <mdb-modal :show="modal" @close="modal = false">
              <mdb-modal-header>
                <mdb-modal-title>QR</mdb-modal-title>
              </mdb-modal-header>
              <mdb-modal-body>
                <qrcode-vue
                class="text-center"
                  :value="idLoteSel"
                  :size="200"
                  :level="'L'"
                ></qrcode-vue>
              </mdb-modal-body>
              <mdb-modal-footer>
                <mdb-btn color="secondary" @click.native="modal = false"
                  >Close</mdb-btn
                >
              </mdb-modal-footer>
            </mdb-modal>
          </div>
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
  mdbModal,
  mdbModalHeader,
  mdbModalTitle,
  mdbModalBody,
  mdbModalFooter,
  mdbBtn
} from "mdbvue";
import { Services, Modal } from "../index";
import QrcodeVue from "qrcode.vue";

export default {
  name: "Tables",
  components: {
    mdbRow,
    mdbCol,
    mdbCard,
    mdbView,
    mdbCardBody,
    mdbTbl,
    Modal,
    mdbModal,
    mdbModalHeader,
    mdbModalTitle,
    mdbModalBody,
    mdbModalFooter,
    mdbBtn,
    QrcodeVue
  },
  data() {
    return {
      fincas: [],
      lotes: [],
      actividades: [],
      verModal: false,
      modal: false,
      idLoteSel: null
    };
  },
  methods: {
    getFincas() {
      Services.get("General/GetFincas")
        .then(res => {
          this.fincas = res;
        })
        .catch(err => {
          console.log(err);
        });
    },

    getLotes() {
      Services.get("General/GetLotesDatos")
        .then(res => {
          this.lotes = res;
        })
        .catch(err => {
          console.log(err);
        });
    },

    getActividades() {
      Services.get("General/GetActividades")
        .then(res => {
          this.actividades = res;
          console.log(res);
        })
        .catch(err => {
          console.log(err);
        });
    },

    verQR(idLote) {
      debugger;
      this.idLoteSel = idLote.toString();
      this.modal = true;
    }
  },
  mounted() {
    this.getFincas();
    this.getLotes();
    this.getActividades();
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
