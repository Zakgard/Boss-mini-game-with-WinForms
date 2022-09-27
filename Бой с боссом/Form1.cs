using System;
using System.Windows.Forms;

namespace Бой_с_боссом
{
    public partial class Form1 : Form
    {
        private double _totalPlayersHp=500;
        private double _totalPlayersMp=200;       
        private double _totalBossHP=5000;
        private ToolTip _toolTip = new ToolTip();
        private string _attackTypePlayer;

        private int _attacTypePlayserNumber;
        private int _bossAttackTypeNumber;

        private bool _isAttackComplete=false;
        
        Random random=new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void ChoosePlayerTypeAttack()
        {
            _attackTypePlayer = comboBox1.Text;
            switch (_attackTypePlayer)
            {
                case "Вызов голлема (Наносит боссу 800 урона, потребляет 100 МП)":
                    _attacTypePlayserNumber = 1;
                    break;
                case "Пространственный разлом (Восстанавливает игроку 100 ХП, тратит 50 МП)":
                    _attacTypePlayserNumber = 2;
                    break;
                case "Проклятие смерти (Наносит 600 урона боссу, тратит 100 ХП)":
                    _attacTypePlayserNumber = 3;
                    break;
                case "Исцеление (восстанаяливает 400 ХП, тратит 200 МП)":
                    _attacTypePlayserNumber = 4;
                    break;
                default:
                    MessageBox.Show("Вы использовали несуществующую атаку!");
                    break;

            }
            PlayerAttack(_attacTypePlayserNumber);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChoosePlayerTypeAttack();
            CheckIfBossDead();
            CheckIfPlayerDead();
        }
        
        private void PlayerAttack(int attackType)
        {
            while (!_isAttackComplete)
            {
                if(attackType == 1)
                   {
                if (_totalPlayersMp >= 100)
                {
                _totalPlayersMp -= 100;
                _totalBossHP -= 800;
                    MessageBox.Show("Вы атаковали босса, используя вызов голлема! Вы нанесли ему 800 урона!");
                        _isAttackComplete = true;
                }
                else
                {
                    MessageBox.Show("Нехватка маны!");
                }
              
            }
            if(attackType == 2)
                {
                if(_totalPlayersMp <= 50)
                {
                   _totalPlayersMp -= 50;
                   _totalPlayersHp += 100;
                    MessageBox.Show("Вы использовали пространственный разлом! Вы восстановили 100 ХП!");
                    _isAttackComplete = true;
                    }
                else
                {
                    MessageBox.Show("Нехватка маны!");
                }
               
            }
            if (attackType == 3)
            {
                if (_totalPlayersHp > 100)
                {
                    _totalPlayersHp -= 100;
                    _totalBossHP -= 600;
                    MessageBox.Show("Вы атаковали босса, используя проклятие смерти! Вы нанесли ему 600 урона!");
                        _isAttackComplete = true;
                    }
                else
                {
                    MessageBox.Show("Нехватка здоровья!");
                }
                
            }
            if (attackType == 4)
            {
                if (_totalPlayersMp >= 200)
                {
                _totalPlayersMp -= 200;
                _totalPlayersHp += 400;
                MessageBox.Show("Вы использовали исцеление! Вы восстановили 400 ХП!");
                        _isAttackComplete = true;
                    }
                else
                {
                    MessageBox.Show("Нехватка маны!");
                }
               
            }
            }

            _isAttackComplete = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(_totalPlayersHp);
            textBox2.Text = Convert.ToString(_totalPlayersMp);
            textBox3.Text = Convert.ToString(_totalBossHP);
            
        }
             

        private void BossAttack()
        {
            _bossAttackTypeNumber=random.Next(1, 2);
            switch (_bossAttackTypeNumber)
            {
                case 1:
                    _totalPlayersHp -= 100;
                    MessageBox.Show("Босс вас атаковал используя обычную атаку! Вы потеряли 100 ХП!");
                    break;
                case 2:
                    _totalPlayersHp -= 300;
                    MessageBox.Show("Босс вас атаковал используя сокрушительную атаку! Вы потеряли 300 ХП!");
                    break;
            }
            textBox3.Text = Convert.ToString(_totalBossHP);
        }

        private void CheckIfBossDead()
        {
            if (_totalBossHP <= 0)
            {
                MessageBox.Show("Вы одолелм босса!");
                textBox3.Text = Convert.ToString(0);
            }else
                BossAttack(); ;
           
        }

        private void CheckIfPlayerDead()
        {
            if (_totalPlayersHp <= 0)
            {
                textBox1.Text = Convert.ToString(0);
                textBox2.Text = Convert.ToString(_totalPlayersMp);
                MessageBox.Show("Вы проиграли!");
            }
            else
            {
                textBox1.Text = Convert.ToString(_totalPlayersHp);
                textBox2.Text = Convert.ToString(_totalPlayersMp);
                MessageBox.Show("Конец раунда! Вы восстанавливаете 100 МП и 50 ХП");
                _totalPlayersMp += 100;
                _totalPlayersHp += 50;
            }
        }
    }
}
