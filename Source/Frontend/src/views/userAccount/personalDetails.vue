<template>
<div>
 <div class="box-info">
      <div class="box-form">
              <v-form ref="personal-details" class="info-form-box">
                <br>
                <el-row>
                  <el-form>
                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="user.systemUser.firstName"
                      :rules="personalDetailRules.FirstName"
                      label="First Name"
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="user.systemUser.lastName"
                      :rules="personalDetailRules.LastName"
                      label="Last Name"
                      required
                    />
                  </el-col>
                </el-row>
                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="user.systemUser.primaryContactNumber"
                      :rules="personalDetailRules.PrimaryContactNumber"
                      label="Primary Contact Number"
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="user.systemUser.mobileNumber"
                      :rules="personalDetailRules.Number"
                      label="Mobile Number"
                    />
                  </el-col>
                </el-row>
                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="user.systemUser.homeNumber"
                      :rules="personalDetailRules.Number"
                      label="Home Number"
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="user.systemUser.workNumber"
                      :rules="personalDetailRules.Number"
                      label="Work Number"
                    />
                  </el-col>
                </el-row>
                <v-layout class="button-layout" align-center justify-center>
                  <!-- <v-btn
                    x-large
                    tile
                    color="#3C565B"
                    width="300px"
                    dark
                    type="submit"
                    class="submit-button"
                    @click="updateDetails()">Update</v-btn> -->
                  <v-btn x-large tile color="#999" width="300px" dark style="margin-left:15px;" @click="$router.go(-1)">Back</v-btn>
                </v-layout>
                            </el-form>
                </el-row>
              </v-form>
      </div>
    </div> 
</div>
</template>

<script>
import { mapGetters } from 'vuex'
import store from '@/store/store'
import { mapState } from 'vuex'
import moment from 'moment'

  export default {
    data () {
      return {
        loading: false,

      personalDetailRules: {
        FirstName: [val => (val || '').length > 0 || 'First Name is required.'],
        LastName: [val => (val || '').length > 0 || 'Last Name is required'],
        PrimaryContactNumber: [val => (val || '').length > 0 || 'Primary Contact Number is required.'],
        Number: [val => (val).length > 0]

      }
      }
    },
      computed: {
               personalDetailformIsValid () {
        return (
          this.user.systemUser.FirstName &&
          this.user.systemUser.LastName &&
          this.user.systemUser.PrimaryContactNumber &&
          this.user.systemUser.MobileNumber
        )
      },

    ...mapState(['user'])
  },
    created() {
   
    if (store.getters.systemUser.length === 0) {
      this.getSystemUser()
    }
  },
    methods: {
    getSystemUser() {
      return this.$store.dispatch('fetchSystemUser')
    },
    updateDetails(){

    }
    }
  }
</script>

<style rel="stylesheet/scss" lang="scss">
.tab-items {
    padding-left: 40px;
    padding-right: 40px;
}

.section-info-header {
  display: block;
  font-size: 16px;
  line-height: 1;
  font-weight: 500;
  text-transform: uppercase;
  color: darkgrey;
  text-align: center;
  padding-top: 5px;
  padding-bottom: 25px;
}

.submit-button{
    margin-left: 10px;
}

.button-area{
    display: flex; 
    justify-content: center;
    margin-top: 40px;
    padding-bottom: 50px;
}
</style>

