package aha_B31_Final_Project;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JTextArea;
import javax.swing.JLabel;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.Font;

public class MorseCodeFrame extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					MorseCodeFrame frame = new MorseCodeFrame();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public MorseCodeFrame() {
		MorseCodeTree t = new MorseCodeTree();
		setTitle("Morse Code Translator");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 574, 428);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		JTextArea morseTextArea = new JTextArea();
		morseTextArea.setFont(new Font("Calibri", Font.BOLD, 19));
		JTextArea letterTextArea = new JTextArea();
		letterTextArea.setFont(new Font("Calibri", Font.BOLD, 19));
		letterTextArea.setWrapStyleWord(true);
		letterTextArea.setLineWrap(true);
		letterTextArea.setBounds(10, 33, 538, 135);
		contentPane.add(letterTextArea);

		JLabel lblWhatToDo = new JLabel("Enter text to encode or code to decode:");
		lblWhatToDo.setBounds(10, 8, 238, 14);
		contentPane.add(lblWhatToDo);

		JButton btnToMorseCode = new JButton("To Morse Code");
		btnToMorseCode.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String letterPhrase = letterTextArea.getText().toLowerCase();
				morseTextArea.setText(t.encode(letterPhrase));
			}
		});
		btnToMorseCode.setBounds(10, 175, 120, 23);
		contentPane.add(btnToMorseCode);

		JButton btnFromMorseCode = new JButton("From Morse Code");
		btnFromMorseCode.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String morseCode = morseTextArea.getText();
				letterTextArea.setText(t.decode(morseCode));
			}
		});
		btnFromMorseCode.setBounds(202, 175, 147, 23);
		contentPane.add(btnFromMorseCode);

		JButton btnClear = new JButton("Clear");
		btnClear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				morseTextArea.setText("");
				letterTextArea.setText("");
			}
		});
		btnClear.setBounds(428, 175, 120, 23);
		contentPane.add(btnClear);

		morseTextArea.setBounds(10, 228, 538, 135);
		contentPane.add(morseTextArea);

		JLabel lblText = new JLabel("Text:");
		lblText.setBounds(502, 8, 46, 14);
		contentPane.add(lblText);

		JLabel lblMorseCode = new JLabel("Morse Code:");
		lblMorseCode.setBounds(476, 209, 72, 14);
		contentPane.add(lblMorseCode);
	}
}
